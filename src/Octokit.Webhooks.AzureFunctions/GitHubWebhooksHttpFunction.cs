namespace Octokit.Webhooks.AzureFunctions;

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
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
public partial class GitHubWebhooksHttpFunction
{
    private readonly IOptions<GitHubWebhooksOptions> options;

    public GitHubWebhooksHttpFunction(IOptions<GitHubWebhooksOptions> options) => this.options = options;

    [Function(nameof(MapGitHubWebhooksAsync))]
    public async Task<HttpResponseData?> MapGitHubWebhooksAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "github/webhooks")] HttpRequestData req,
        FunctionContext ctx)
    {
        var logger = ctx.InstanceServices.GetService<ILogger<GitHubWebhooksHttpFunction>>()!;

        // Verify content type
        if (!VerifyContentType(req, MediaTypeNames.Application.Json))
        {
            Log.IncorrectContentType(logger);
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        // Get body
        var body = await GetBodyAsync(req).ConfigureAwait(false);

        // Verify signature
        if (!VerifySignature(req, this.options.Value.Secret, body))
        {
            Log.SignatureValidationFailed(logger);
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        // Process body
        try
        {
            var service = ctx.InstanceServices.GetService<WebhookEventProcessor>()!;
            var headers = req.Headers.ToDictionary(
                kv => kv.Key,
                kv => new StringValues(kv.Value.ToArray()),
                StringComparer.OrdinalIgnoreCase);
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

    private static bool VerifyContentType(HttpRequestData req, string expectedContentType)
    {
        var contentHeader = req.Headers.GetValues("Content-Type").FirstOrDefault();
        if (contentHeader is null)
        {
            return false;
        }

        var contentType = new ContentType(contentHeader);
        if (contentType.MediaType != expectedContentType)
        {
            return false;
        }

        return true;
    }

    private static async Task<string> GetBodyAsync(HttpRequestData req)
    {
        using var reader = new StreamReader(req.Body);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }

    private static bool VerifySignature(HttpRequestData req, string? secret, string body)
    {
        var isSigned = req.Headers.TryGetValues("X-Hub-Signature-256", out var signatureHeader);
        var signature = signatureHeader?.FirstOrDefault();

        var isSignatureExpected = !string.IsNullOrEmpty(secret);

        if (!isSigned && !isSignatureExpected)
        {
            // Nothing to do.
            return true;
        }

        if (!isSigned && isSignatureExpected)
        {
            return false;
        }

        if (isSigned && !isSignatureExpected)
        {
            return false;
        }

        var keyBytes = Encoding.UTF8.GetBytes(secret!);
        var bodyBytes = Encoding.UTF8.GetBytes(body);

        var hash = HMACSHA256.HashData(keyBytes, bodyBytes);
        var hashHex = Convert.ToHexString(hash);
        var expectedHeader = $"sha256={hashHex.ToLower(CultureInfo.InvariantCulture)}";
        return signature == expectedHeader;
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
