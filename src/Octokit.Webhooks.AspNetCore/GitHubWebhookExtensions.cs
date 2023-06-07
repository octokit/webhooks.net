namespace Octokit.Webhooks.AspNetCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

/// <summary>
/// A class containing extension methods for <see cref="IEndpointRouteBuilder"/>
/// for adding an HTTP endpoint for processing GitHub webhook payloads.
/// </summary>
public static partial class GitHubWebhookExtensions
{
    /// <inheritdoc cref="MapGitHubWebhooks(IEndpointRouteBuilder,string,Func{Task{IEnumerable{string}?}})"/>
    /// <param name="endpoints">
    /// The <c>Microsoft.AspNetCore.Routing.IEndpointRouteBuilder</c> to add the route to.
    /// </param>
    /// <param name="path">The path of the webhook endpoint.</param>
    /// <param name="secret">
    /// The secret to use to validate each webhook request's signature, or null if no signature is
    /// to be expected.
    /// </param>
    public static void MapGitHubWebhooks(this IEndpointRouteBuilder endpoints, string path = "/api/github/webhooks", string secret = null!)
    {
        var secrets = string.IsNullOrEmpty(secret) ? null : new string[] { secret };
        MapGitHubWebhooks(endpoints, path, () => Task.FromResult<IEnumerable<string>?>(secrets));
    }

    /// <summary>
    /// Adds an endpoint for processing GitHub webhook payloads.
    /// </summary>
    /// <param name="endpoints">
    /// The <c>Microsoft.AspNetCore.Routing.IEndpointRouteBuilder</c> to add the route to.
    /// </param>
    /// <param name="path">The path of the webhook endpoint.</param>
    /// <param name="secrets">
    /// A callback delegate that will return the list of secrets to use to validate a request's
    /// signature.
    /// </param>
    /// <remarks>
    /// <para>
    /// The <paramref name="secrets"/> delegate will be invoked once for each request. If the
    /// delegate returns null, then no signature will be expected. If the delegate returns a list of
    /// one or more secrets, then the request's signature must match one of those secrets. If the
    /// delegate returns an empty list, then the request's signature will be considered invalid.
    /// </para>
    /// <para>
    /// Because the delegate is invoked separately for each request, the webhook secret can be
    /// changed without modifying the route. Returning bpth the old and the new secrets for some
    /// time will allow any webhook requests already in flight to validate against the old secret
    /// while any new requests will validate against the new secret.
    /// </para>
    /// </remarks>
    public static void MapGitHubWebhooks(this IEndpointRouteBuilder endpoints, string path, Func<Task<IEnumerable<string>?>> secrets) =>
        endpoints.MapPost(path, async context =>
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<WebhookEventProcessor>>();

            // Validate request
            string body;
            try
            {
                var secretsList = await secrets().ConfigureAwait(false);
                body = await WebhookEventProcessor.ValidateWebhookRequestAsync(context.Request.Headers, context.Request.Body, secretsList).ConfigureAwait(false);
            }
            catch (WebhookValidationException e)
            {
                context.Response.StatusCode = (int)e.StatusCode;
                switch (e.Error)
                {
                    case WebhookValidationError.IncorrectContentType:
                        Log.IncorrectContentType(logger);
                        break;

                    case WebhookValidationError.InvalidSignature:
                    case WebhookValidationError.MissingSignature:
                    case WebhookValidationError.UnexpectedSignature:
                        Log.SignatureValidationFailed(logger);
                        if (e.Error == WebhookValidationError.UnexpectedSignature)
                        {
                            // Add error response content to help with debugging webhook failure.
                            await context.Response.WriteAsync("Payload includes a secret, so the webhook receiver must configure a secret.")
                                .ConfigureAwait(false);
                        }

                        break;

                    default:
                        break;
                }

                return;
            }

            // Process body
            try
            {
                var service = context.RequestServices.GetRequiredService<WebhookEventProcessor>();
                await service.ProcessWebhookAsync(context.Request.Headers, body)
                    .ConfigureAwait(false);
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Log.ProcessingFailed(logger, ex);
                context.Response.StatusCode = 500;
            }
        });

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
    }
}
