namespace Octokit.Webhooks.AzureFunctions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
public sealed partial class GitHubWebhooksHttpFunction
{
    private readonly IOptions<GitHubWebhooksOptions> options;
    private readonly Func<Task<IEnumerable<string>?>> secretsCallback;

    public GitHubWebhooksHttpFunction(IOptions<GitHubWebhooksOptions> options)
    {
        this.options = options;

        if ((options.Value.Secret != null) && (options.Value.SecretsCallback != null))
        {
            throw new ArgumentException($"The '{nameof(options.Value.Secret)}' and '{nameof(options.Value.SecretsCallback)}' properties are mutually exclusive.");
        }

        if (options.Value.SecretsCallback != null)
        {
            this.secretsCallback = options.Value.SecretsCallback;
        }
        else
        {
            var secret = options.Value.Secret;
            var secrets = (secret != null) ? new string[] { secret } : null;
            this.secretsCallback = () => Task.FromResult<IEnumerable<string>?>(secrets);
        }
    }

    [Function(nameof(MapGitHubWebhooksAsync))]
    public async Task<HttpResponseData?> MapGitHubWebhooksAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "github/webhooks")] HttpRequestData req,
        FunctionContext ctx)
    {
        var logger = ctx.GetLogger(nameof(GitHubWebhooksHttpFunction));

        var secrets = await this.secretsCallback().ConfigureAwait(false);

        var headers = req.Headers.ToDictionary(
            kv => kv.Key,
            kv => new StringValues(kv.Value.ToArray()),
            StringComparer.OrdinalIgnoreCase);

        // Validate the request.
        string body;
        try
        {
            body = await WebhookEventProcessor.ValidateWebhookRequestAsync(headers, req.Body, secrets).ConfigureAwait(false);
        }
        catch (WebhookValidationException e)
        {
            switch (e.Error)
            {
                case WebhookValidationError.IncorrectContentType:
                    Log.IncorrectContentType(logger);
                    break;

                case WebhookValidationError.InvalidSignature:
                case WebhookValidationError.MissingSignature:
                case WebhookValidationError.UnexpectedSignature:
                    Log.SignatureValidationFailed(logger);
                    break;

                default:
                    break;
            }

            return req.CreateResponse(e.StatusCode);
        }

        // Process body
        try
        {
            var service = ctx.InstanceServices.GetRequiredService<WebhookEventProcessor>();
            await service.ProcessWebhookAsync(headers, body)
                .ConfigureAwait(false);
            return req.CreateResponse(HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            Log.ProcessingFailed(logger, ex);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    private static async Task<string> GetBodyAsync(HttpRequestData req)
    {
        using var reader = new StreamReader(req.Body);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
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
    }
}
