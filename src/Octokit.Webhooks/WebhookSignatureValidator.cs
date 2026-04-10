namespace Octokit.Webhooks;

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides methods to verify GitHub webhook payload signatures.
/// </summary>
public static class WebhookSignatureValidator
{
    /// <summary>
    /// Verifies the signature of a GitHub webhook payload.
    /// </summary>
    /// <param name="signatureHeader">The value of the <c>X-Hub-Signature-256</c> header, or <see langword="null"/> or an empty string if not present.</param>
    /// <param name="secret">The configured webhook secret, or <see langword="null"/> or an empty string if not configured.</param>
    /// <param name="body">The raw request body.</param>
    /// <returns>A <see cref="WebhookSignatureValidationResult"/> indicating the outcome of the validation.</returns>
    public static WebhookSignatureValidationResult Verify(string? signatureHeader, string? secret, string body)
    {
        ArgumentNullException.ThrowIfNull(body);

        var isSigned = !string.IsNullOrEmpty(signatureHeader);
        var isSignatureExpected = !string.IsNullOrEmpty(secret);

        if (!isSigned && !isSignatureExpected)
        {
            return WebhookSignatureValidationResult.Valid;
        }

        if (!isSigned && isSignatureExpected)
        {
            return WebhookSignatureValidationResult.MissingSignature;
        }

        if (isSigned && !isSignatureExpected)
        {
            return WebhookSignatureValidationResult.MissingSecret;
        }

        var keyBytes = Encoding.UTF8.GetBytes(secret!);
        var bodyBytes = Encoding.UTF8.GetBytes(body);

        var hash = HMACSHA256.HashData(keyBytes, bodyBytes);
        var hashHex = Convert.ToHexString(hash);
        var expectedHeader = $"sha256={hashHex.ToLower(CultureInfo.InvariantCulture)}";

        var expectedBytes = Encoding.UTF8.GetBytes(expectedHeader);
        var actualBytes = Encoding.UTF8.GetBytes(signatureHeader!);

        if (!CryptographicOperations.FixedTimeEquals(expectedBytes, actualBytes))
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        return WebhookSignatureValidationResult.Valid;
    }
}
