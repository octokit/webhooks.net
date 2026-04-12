namespace Octokit.Webhooks;

using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides methods to verify GitHub webhook payload signatures.
/// </summary>
[PublicAPI]
public static class WebhookSignatureValidator
{
    private const string Prefix = "sha256=";

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

        if (!signatureHeader!.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase))
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        var signatureHex = signatureHeader![Prefix.Length..];

        byte[] signatureBytes;
        try
        {
            signatureBytes = Convert.FromHexString(signatureHex);
        }
        catch (FormatException)
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        if (signatureBytes.Length != 32)
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        Span<byte> keyBytes = stackalloc byte[Encoding.UTF8.GetByteCount(secret!)];
        Encoding.UTF8.GetBytes(secret!, keyBytes);
        var bodyBytes = Encoding.UTF8.GetBytes(body);
        var expectedHash = HMACSHA256.HashData(keyBytes, bodyBytes);

        if (!CryptographicOperations.FixedTimeEquals(expectedHash, signatureBytes))
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        return WebhookSignatureValidationResult.Valid;
    }
}
