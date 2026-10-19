namespace Octokit.Webhooks;

using System;
using System.Buffers;
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

        var bodyByteCount = Encoding.UTF8.GetByteCount(body);
        var bodyBytesArray = ArrayPool<byte>.Shared.Rent(bodyByteCount);
        try
        {
            var bodyBytes = bodyBytesArray.AsSpan(0, bodyByteCount);
            Encoding.UTF8.GetBytes(body, bodyBytes);
            return Verify(signatureHeader, secret, bodyBytes);
        }
        finally
        {
            bodyBytesArray.AsSpan(0, bodyByteCount).Clear();
            ArrayPool<byte>.Shared.Return(bodyBytesArray);
        }
    }

    /// <summary>
    /// Verifies the signature of a GitHub webhook payload from raw UTF-8 bytes.
    /// </summary>
    /// <param name="signatureHeader">The value of the <c>X-Hub-Signature-256</c> header, or <see langword="null"/> or an empty string if not present.</param>
    /// <param name="secret">The configured webhook secret, or <see langword="null"/> or an empty string if not configured.</param>
    /// <param name="bodyUtf8">The raw request body as UTF-8 bytes.</param>
    /// <returns>A <see cref="WebhookSignatureValidationResult"/> indicating the outcome of the validation.</returns>
    public static WebhookSignatureValidationResult Verify(string? signatureHeader, string? secret, ReadOnlySpan<byte> bodyUtf8)
    {
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

        var signatureHex = signatureHeader.AsSpan(Prefix.Length);

        if (signatureHex.Length != 64)
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        Span<byte> signatureBytes = stackalloc byte[32];

#if NET9_0_OR_GREATER
        if (Convert.FromHexString(signatureHex, signatureBytes, out _, out var bytesDecoded) != OperationStatus.Done ||
            bytesDecoded != signatureBytes.Length)
#else
        if (!TryDecodeHex(signatureHex, signatureBytes))
#endif
        {
            return WebhookSignatureValidationResult.SignatureMismatch;
        }

        var keyByteCount = Encoding.UTF8.GetByteCount(secret!);
        var keyBuffer = keyByteCount <= 256
            ? stackalloc byte[keyByteCount]
            : new byte[keyByteCount];

        try
        {
            if (Encoding.UTF8.GetBytes(secret!, keyBuffer) != keyByteCount)
            {
                return WebhookSignatureValidationResult.SignatureMismatch;
            }

            Span<byte> expectedHash = stackalloc byte[32];
            if (!HMACSHA256.TryHashData(keyBuffer, bodyUtf8, expectedHash, out var bytesWritten)
                || bytesWritten != expectedHash.Length)
            {
                return WebhookSignatureValidationResult.SignatureMismatch;
            }

            if (!CryptographicOperations.FixedTimeEquals(expectedHash, signatureBytes))
            {
                return WebhookSignatureValidationResult.SignatureMismatch;
            }

            return WebhookSignatureValidationResult.Valid;
        }
        finally
        {
            keyBuffer.Clear();
        }
    }

#if !NET9_0_OR_GREATER
    private static bool TryDecodeHex(ReadOnlySpan<char> hex, Span<byte> destination)
    {
        for (var i = 0; i < destination.Length; i++)
        {
            var high = HexValue(hex[2 * i]);
            var low = HexValue(hex[(2 * i) + 1]);

            if ((high | low) < 0)
            {
                return false;
            }

            destination[i] = (byte)((high << 4) | low);
        }

        return true;
    }

    private static int HexValue(char value) => value switch
    {
        >= '0' and <= '9' => value - '0',
        >= 'a' and <= 'f' => value - 'a' + 10,
        >= 'A' and <= 'F' => value - 'A' + 10,
        _ => -1,
    };
#endif
}
