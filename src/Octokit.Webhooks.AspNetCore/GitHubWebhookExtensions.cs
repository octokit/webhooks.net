namespace Octokit.Webhooks.AspNetCore;

using System;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

/// <summary>
/// A class containing extension methods for <see cref="IEndpointRouteBuilder"/>
/// for adding an HTTP endpoint for processing GitHub webhook payloads.
/// </summary>
public static partial class GitHubWebhookExtensions
{
    public static IEndpointConventionBuilder MapGitHubWebhooks(
        this IEndpointRouteBuilder endpoints,
        string path = "/api/github/webhooks",
        string? secret = null)
    {
        var options = endpoints.ServiceProvider.GetService<IOptionsMonitor<GitHubWebhookOptions>>();
        return endpoints.MapPost(
            path,
            async context =>
            {
                var logger = context.RequestServices.GetRequiredService<ILogger<WebhookEventProcessor>>();

                // Verify content type
                if (!VerifyContentType(context, MediaTypeNames.Application.Json))
                {
                    Log.IncorrectContentType(logger);
                    return;
                }

                // Verify event type
                if (!VerifyEventType(context))
                {
                    Log.MissingEventType(logger);
                    return;
                }

                try
                {
                    // Get body as bytes to avoid string allocation
                    var body = await GetBodyBytesAsync(context, context.RequestAborted).ConfigureAwait(false);

                    if (secret is null && options is not null)
                    {
                        secret = options.CurrentValue.Secret;
                    }

                    // Verify signature
                    if (!await VerifySignatureAsync(context, secret, body).ConfigureAwait(false))
                    {
                        Log.SignatureValidationFailed(logger);
                        return;
                    }

                    // Process body
                    var service = context.RequestServices.GetRequiredService<WebhookEventProcessor>();
                    await service.ProcessWebhookAsync(context.Request.Headers, (ReadOnlyMemory<byte>)body, context.RequestAborted)
                        .ConfigureAwait(false);
                    context.Response.StatusCode = 200;
                }
                catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
                {
                    Log.RequestCancelled(logger);
                }
                catch (Exception ex)
                {
                    Log.ProcessingFailed(logger, ex);
                    context.Response.StatusCode = 500;
                }
            });
    }

    private static bool VerifyContentType(HttpContext context, string expectedContentType)
    {
        if (context.Request.ContentType is null)
        {
            return false;
        }

        var contentType = new ContentType(context.Request.ContentType);
        if (contentType.MediaType != expectedContentType)
        {
            context.Response.StatusCode = 400;
            return false;
        }

        return true;
    }

    private static async Task<byte[]> GetBodyBytesAsync(HttpContext context, CancellationToken cancellationToken)
    {
        if (context.Request.ContentLength is > 0 and long contentLength && contentLength <= int.MaxValue)
        {
            var buffer = new byte[(int)contentLength];
            await context.Request.Body.ReadExactlyAsync(buffer, cancellationToken).ConfigureAwait(false);
            return buffer;
        }

        using var ms = new MemoryStream();
        await context.Request.Body.CopyToAsync(ms, cancellationToken).ConfigureAwait(false);
        return ms.ToArray();
    }

    private static bool VerifyEventType(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-GitHub-Event", out var eventType)
            || eventType.Count != 1
            || string.IsNullOrWhiteSpace(eventType.ToString()))
        {
            context.Response.StatusCode = 400;
            return false;
        }

        return true;
    }

    private static async Task<bool> VerifySignatureAsync(HttpContext context, string? secret, byte[] body)
    {
        _ = context.Request.Headers.TryGetValue("X-Hub-Signature-256", out var signatureSha256);

        var result = WebhookSignatureValidator.Verify(signatureSha256.ToString(), secret, (ReadOnlySpan<byte>)body);

        switch (result)
        {
            case WebhookSignatureValidationResult.Valid:
                return true;
            case WebhookSignatureValidationResult.MissingSignature:
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Expected an X-Hub-Signature-256 header but none was provided. Configure a webhook secret on the sender, or remove the secret from the receiver.")
                    .ConfigureAwait(false);
                return false;
            case WebhookSignatureValidationResult.MissingSecret:
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Request includes an X-Hub-Signature-256 header but no secret is configured on the receiver.")
                    .ConfigureAwait(false);
                return false;
            case WebhookSignatureValidationResult.SignatureMismatch:
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("X-Hub-Signature-256 does not match the expected signature. Verify that the webhook secret matches on both sender and receiver.")
                    .ConfigureAwait(false);
                return false;
            default:
                context.Response.StatusCode = 400;
                return false;
        }
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
