namespace Octokit.Webhooks
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Mime;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    internal class WebhookUtilities
    {
        public sealed class VerifyResult<T>
        {
            public T Value { get; init; } = default!;

            public HttpStatusCode StatusCode;
            public string? StatusBody;

            public VerifyResult(T value)
            {
                this.Value = value;
                this.StatusCode = HttpStatusCode.OK;
            }

            public VerifyResult(HttpStatusCode statusCode, string statusBody)
            {
                this.StatusCode = statusCode;
                this.StatusBody = statusBody;
            }
        }

        private static VerifyResult<bool> VerifyContentType(HttpRequest req, string expected)
        {
            if (expected == req.ContentType)
            {
                return new VerifyResult<bool>(true);
            }
            return new VerifyResult<bool>(HttpStatusCode.BadRequest, "Unexpected content type");
        }

        private static async Task<string> GetBodyAsync(HttpRequest request)
        {
            using var reader = new StreamReader(request.Body);
            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }

        private static async Task<VerifyResult<string>> VerifySignature(HttpRequest request, string secret)
        {
            var body = await GetBodyAsync(request).ConfigureAwait(false);
            request.Headers.TryGetValue("X-Hub-Signature-256", out var signatureSha256);

            var isSigned = signatureSha256.Count > 0;
            var isSignatureExpected = !string.IsNullOrEmpty(secret);

            if (!isSigned && !isSignatureExpected)
            {
                return new VerifyResult<string>(body);
            }

            if (!isSigned && isSignatureExpected)
            {
                return new VerifyResult<string>(HttpStatusCode.BadRequest, "Missing signature header");
            }

            if (isSigned && !isSignatureExpected)
            {
                return new VerifyResult<string>(HttpStatusCode.InternalServerError,
                    "Payload includes a secret, so the webhook receiver must configure a secret.");
            }

            var keyBytes = Encoding.UTF8.GetBytes(secret);
            var bodyBytes = Encoding.UTF8.GetBytes(body);
            var hmac = new HMACSHA256(keyBytes);
            var hash = hmac.ComputeHash(bodyBytes);
            var hashHex = Convert.ToHexString(hash);
            var expectedHeader = $"sha256={hashHex.ToLower(CultureInfo.InvariantCulture)}";
            if (signatureSha256.ToString() != expectedHeader)
            {
                return new VerifyResult<string>(HttpStatusCode.BadRequest, "Signature mismatch");
            }

            return new VerifyResult<string>(body);
        }

        public static async Task<VerifyResult<string>> GetBodyChecked(HttpRequest request, string secret)
        {
            // Verify content type
            var vct = VerifyContentType(request, MediaTypeNames.Application.Json);
            if (vct.StatusCode != HttpStatusCode.OK)
            {
                return new VerifyResult<string>(vct.StatusCode, vct.StatusBody);
            }

            // Require a length up front and that it not be too long
            if (request.ContentLength == 0)
            {
                return new VerifyResult<string>(HttpStatusCode.LengthRequired, String.Empty);
            }

            if (request.ContentLength > 1024 * 1024)
            {
                return new VerifyResult<string>(HttpStatusCode.RequestEntityTooLarge,
                    "Refusing to process overlong message");
            }

            // Extract body and verify signature
            return await VerifySignature(request, secret);
        }
    }
}
