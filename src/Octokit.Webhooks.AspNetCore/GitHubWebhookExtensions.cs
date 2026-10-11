namespace Octokit.Webhooks.AspNetCore;

using System;
using System.Buffers;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

/// <summary>
/// A class containing extension methods for <see cref="IEndpointRouteBuilder"/>
/// for adding an HTTP endpoint for processing GitHub webhook payloads.
/// </summary>
public static partial class GitHubWebhookExtensions
{
    // The buffer size used to read the request body when Content-Length is unknown.
    private const int DefaultBufferSize = 16 * 1024;

    // Content-Length is client-controlled, so cap the buffer rented before any of the body has been
    // received. Bodies that are genuinely larger grow the buffer as bytes actually arrive.
    private const int MaxInitialBufferSize = 64 * 1024;

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
                // Verify content type
                if (!VerifyContentType(context, MediaTypeNames.Application.Json))
                {
                    Log.IncorrectContentType(GetLogger(context));
                    return;
                }

                // Verify event type
                if (!VerifyEventType(context))
                {
                    Log.MissingEventType(GetLogger(context));
                    return;
                }

                byte[]? buffer = null;
                var length = 0;
                try
                {
                    // Read the body into a pooled buffer to avoid per-request array and string allocations
                    (buffer, length) = await ReadBodyAsync(context.Request, context.RequestAborted).ConfigureAwait(false);
                    var body = buffer.AsMemory(0, length);

                    var webhookSecret = secret ?? options?.CurrentValue.Secret;

                    // Verify signature
                    if (!await VerifySignatureAsync(context, webhookSecret, body).ConfigureAwait(false))
                    {
                        Log.SignatureValidationFailed(GetLogger(context));
                        return;
                    }

                    // Process body
                    var service = context.RequestServices.GetRequiredService<WebhookEventProcessor>();
                    await service.ProcessWebhookAsync(context.Request.Headers, body, context.RequestAborted)
                        .ConfigureAwait(false);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                }
                catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
                {
                    Log.RequestCancelled(GetLogger(context));
                }
                catch (Exception ex)
                {
                    if (options?.CurrentValue.ExceptionHandler is { } exceptionHandler
                        && await exceptionHandler(ex, context).ConfigureAwait(false))
                    {
                        return;
                    }

                    Log.ProcessingFailed(GetLogger(context), ex);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
                finally
                {
                    if (buffer is not null)
                    {
                        ReturnBuffer(buffer, length);
                    }
                }
            });
    }

    private static ILogger GetLogger(HttpContext context)
        => context.RequestServices.GetRequiredService<ILogger<WebhookEventProcessor>>();

    private static bool VerifyContentType(HttpContext context, string expectedMediaType)
    {
        if (!HasMediaType(context.Request.ContentType, expectedMediaType))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return false;
        }

        return true;
    }

    private static bool HasMediaType(string? contentType, string expectedMediaType)
    {
        if (string.IsNullOrEmpty(contentType))
        {
            return false;
        }

        // GitHub sends "application/json" with no parameters, so most requests take this allocation-free path.
        // Media types are case-insensitive.
        if (string.Equals(contentType, expectedMediaType, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // Otherwise fully parse the header so that malformed values, which would have made
        // System.Net.Mime.ContentType throw, are rejected rather than accepted or causing an HTTP 500.
        if (!MediaTypeHeaderValue.TryParse(contentType, out var mediaType) ||
            !mediaType.MediaType.Equals(expectedMediaType, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // The parser tolerates parameters with no value (e.g. "application/json; charset"), which is not valid syntax.
        foreach (var parameter in mediaType.Parameters)
        {
            if (StringSegment.IsNullOrEmpty(parameter.Value))
            {
                return false;
            }
        }

        return true;
    }

    private static async ValueTask<(byte[] Buffer, int Length)> ReadBodyAsync(HttpRequest request, CancellationToken cancellationToken)
    {
        // Rent one byte more than the declared Content-Length (up to the cap) so that a well-formed body
        // is read to completion (the final read returning zero) without the buffer ever needing to grow.
        // If the length is unknown (e.g. chunked), capped, or the body is longer than declared, the buffer grows.
        var contentLength = request.ContentLength;
        var initialSize = contentLength > 0 ? (int)Math.Min(contentLength.Value, MaxInitialBufferSize - 1) + 1 : DefaultBufferSize;
        var buffer = ArrayPool<byte>.Shared.Rent(initialSize);
        var length = 0;

        try
        {
            while (true)
            {
                if (length == buffer.Length)
                {
                    // Now that as many bytes as were rented have actually arrived, honour a declared
                    // Content-Length above the initial cap so that the client needs only one grow.
                    var newSize = checked(buffer.Length * 2);
                    if (contentLength >= newSize)
                    {
                        newSize = (int)Math.Min(contentLength.Value, Array.MaxLength - 1) + 1;
                    }

                    var larger = ArrayPool<byte>.Shared.Rent(newSize);
                    buffer.AsSpan(0, length).CopyTo(larger);
                    ReturnBuffer(buffer, length);
                    buffer = larger;
                }

                var read = await request.Body.ReadAsync(buffer.AsMemory(length), cancellationToken).ConfigureAwait(false);
                if (read == 0)
                {
                    return (buffer, length);
                }

                length += read;
            }
        }
        catch
        {
            ReturnBuffer(buffer, length);
            throw;
        }
    }

    private static void ReturnBuffer(byte[] buffer, int length)
    {
        // Only the portion that held payload data needs clearing before the buffer is reused.
        buffer.AsSpan(0, length).Clear();
        ArrayPool<byte>.Shared.Return(buffer);
    }

    private static bool VerifyEventType(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-GitHub-Event", out var eventType)
            || eventType.Count != 1
            || string.IsNullOrWhiteSpace(eventType.ToString()))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return false;
        }

        return true;
    }

    private static async Task<bool> VerifySignatureAsync(HttpContext context, string? secret, ReadOnlyMemory<byte> body)
    {
        _ = context.Request.Headers.TryGetValue("X-Hub-Signature-256", out var signatureSha256);

        var result = WebhookSignatureValidator.Verify(signatureSha256.ToString(), secret, body.Span);

        switch (result)
        {
            case WebhookSignatureValidationResult.Valid:
                return true;
            case WebhookSignatureValidationResult.MissingSignature:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Expected an X-Hub-Signature-256 header but none was provided. Configure a webhook secret on the sender, or remove the secret from the receiver.")
                    .ConfigureAwait(false);
                return false;
            case WebhookSignatureValidationResult.MissingSecret:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Request includes an X-Hub-Signature-256 header but no secret is configured on the receiver.")
                    .ConfigureAwait(false);
                return false;
            case WebhookSignatureValidationResult.SignatureMismatch:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("X-Hub-Signature-256 does not match the expected signature. Verify that the webhook secret matches on both sender and receiver.")
                    .ConfigureAwait(false);
                return false;
            default:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
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
