namespace JamieMagee.Octokit.Webhooks.AspNetCore
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net.Mime;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.DependencyInjection;

    public static class GitHubWebhookExtensions
    {
        public static void MapGitHubWebhook(this IEndpointRouteBuilder endpoints, string path = "/api/github/webhooks", string secret = null!) =>
            endpoints.MapPost(path, async context =>
            {
                // Verify content type
                if (!VerifyContentType(context, MediaTypeNames.Application.Json))
                {
                    return;
                }

                // Get body
                var body = await GetBodyAsync(context).ConfigureAwait(false);

                // Verify signature
                if (!await VerifySignatureAsync(context, secret, body).ConfigureAwait(false))
                {
                    return;
                }

                // Process body
                try
                {
                    var service = context.RequestServices.GetRequiredService<WebhookEventProcessor>();
                    service.ProcessWebhook(context.Request.Headers, body);
                    context.Response.StatusCode = 200;
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 500;
                }
            });

        private static bool VerifyContentType(HttpContext context, string expectedContentType)
        {
            var contentType = new ContentType(context.Request.ContentType);
            if (contentType.MediaType != expectedContentType)
            {
                context.Response.StatusCode = 400;
                return false;
            }

            return true;
        }

        private static async Task<string> GetBodyAsync(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body);
            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }

        private static async Task<bool> VerifySignatureAsync(HttpContext context, string secret, string body)
        {
            context.Request.Headers.TryGetValue("X-Hub-Signature-256", out var signatureSha256);

            var isSigned = signatureSha256.Count > 0;
            var isSignatureExpected = !string.IsNullOrEmpty(secret);

            if (!isSigned && !isSignatureExpected)
            {
                // Nothing to do.
                return true;
            }

            if (!isSigned && isSignatureExpected)
            {
                context.Response.StatusCode = 400;
                return false;
            }

            if (isSigned && !isSignatureExpected)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Payload includes a secret, so the webhook receiver must configure a secret.")
                    .ConfigureAwait(false);
                return false;
            }

            var keyBytes = Encoding.UTF8.GetBytes(secret);
            var bodyBytes = Encoding.UTF8.GetBytes(body);

            using var hmac = new HMACSHA256(keyBytes);
            var hash = hmac.ComputeHash(bodyBytes);
            var hashHex = Convert.ToHexString(hash);
            var expectedHeader = $"sha256={hashHex.ToLower(CultureInfo.InvariantCulture)}";
            if (signatureSha256.ToString() != expectedHeader)
            {
                context.Response.StatusCode = 400;
                return false;
            }

            return true;
        }
    }
}
