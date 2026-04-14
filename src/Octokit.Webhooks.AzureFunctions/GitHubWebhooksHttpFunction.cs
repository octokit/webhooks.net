namespace Octokit.Webhooks.AzureFunctions;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

/// <summary>
/// A class containing an Azure Function that processes GitHub webhooks.
/// </summary>
public sealed partial class GitHubWebhooksHttpFunction(IOptions<GitHubWebhooksOptions> options)
{
    [Function(nameof(MapGitHubWebhooksAsync))]
    public async Task<HttpResponseData?> MapGitHubWebhooksAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "github/webhooks")] HttpRequestData req,
        FunctionContext ctx)
    {
        var logger = ctx.GetLogger(nameof(GitHubWebhooksHttpFunction));

        // Verify content type
        if (!VerifyContentType(req, MediaTypeNames.Application.Json))
        {
            Log.IncorrectContentType(logger);
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        // Verify event type
        if (!VerifyEventType(req))
        {
            Log.MissingEventType(logger);
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        try
        {
            var body = await GetBodyBytesAsync(req, ctx.CancellationToken).ConfigureAwait(false);

            // Verify signature
            var signatureResult = VerifySignature(req, options.Value.Secret, body);
            if (signatureResult != WebhookSignatureValidationResult.Valid)
            {
                Log.SignatureValidationFailed(logger);
                var response = req.CreateResponse(HttpStatusCode.BadRequest);
                var message = signatureResult switch
                {
                    WebhookSignatureValidationResult.MissingSignature =>
                        "Expected an X-Hub-Signature-256 header but none was provided. Configure a webhook secret on the sender, or remove the secret from the receiver.",
                    WebhookSignatureValidationResult.MissingSecret =>
                        "Request includes an X-Hub-Signature-256 header but no secret is configured on the receiver.",
                    WebhookSignatureValidationResult.SignatureMismatch =>
                        "X-Hub-Signature-256 does not match the expected signature. Verify that the webhook secret matches on both sender and receiver.",
                    _ => "Signature validation failed.",
                };
                await response.WriteStringAsync(message).ConfigureAwait(false);
                return response;
            }

            // Process body
            var service = ctx.InstanceServices.GetRequiredService<WebhookEventProcessor>();
            var headers = req.Headers.ToDictionary(
                kv => kv.Key,
                kv => new StringValues([.. kv.Value]),
                StringComparer.OrdinalIgnoreCase);
            await service.ProcessWebhookAsync(headers, (ReadOnlyMemory<byte>)body, ctx.CancellationToken)
                .ConfigureAwait(false);
            return req.CreateResponse(HttpStatusCode.OK);
        }
        catch (OperationCanceledException) when (ctx.CancellationToken.IsCancellationRequested)
        {
            Log.RequestCancelled(logger);
            return null;
        }
        catch (Exception ex)
        {
            Log.ProcessingFailed(logger, ex);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    private static bool VerifyContentType(HttpRequestData req, string expectedContentType)
    {
        var contentHeader = req.Headers.GetValues("Content-Type").FirstOrDefault();
        if (contentHeader is null)
        {
            return false;
        }

        var contentType = new ContentType(contentHeader);
        return contentType.MediaType == expectedContentType;
    }

    private static async Task<byte[]> GetBodyBytesAsync(HttpRequestData req, CancellationToken cancellationToken)
    {
        using var ms = new MemoryStream();
        await req.Body.CopyToAsync(ms, cancellationToken).ConfigureAwait(false);
        return ms.ToArray();
    }

    private static bool VerifyEventType(HttpRequestData req)
    {
        if (!req.Headers.TryGetValues("X-GitHub-Event", out var eventValues))
        {
            return false;
        }

        var values = eventValues.ToList();
        return values.Count == 1 && !string.IsNullOrWhiteSpace(values[0]);
    }

    private static WebhookSignatureValidationResult VerifySignature(HttpRequestData req, string? secret, byte[] body)
    {
        _ = req.Headers.TryGetValues("X-Hub-Signature-256", out var signatureHeader);
        var signature = signatureHeader?.FirstOrDefault();

        return WebhookSignatureValidator.Verify(signature, secret, (ReadOnlySpan<byte>)body);
    }

    /// <summary>
    /// Log messages for the class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    internal static partial class Log
    {
        [LoggerMessage(
            EventId = 1,
            Level = LogLevel.Error,
            Message = "GitHub event does not have the correct content type.")]
        public static partial void IncorrectContentType(ILogger logger);

        [LoggerMessage(
            EventId = 2,
            Level = LogLevel.Error,
            Message = "GitHub event failed signature validation.")]
        public static partial void SignatureValidationFailed(ILogger logger);

        [LoggerMessage(
            EventId = 3,
            Level = LogLevel.Error,
            Message = "Exception processing GitHub event.")]
        public static partial void ProcessingFailed(ILogger logger, Exception exception);

        [LoggerMessage(
            EventId = 4,
            Level = LogLevel.Warning,
            Message = "GitHub event request was cancelled.")]
        public static partial void RequestCancelled(ILogger logger);

        [LoggerMessage(
            EventId = 5,
            Level = LogLevel.Error,
            Message = "GitHub event has a missing or invalid event type header.")]
        public static partial void MissingEventType(ILogger logger);
    }
}
