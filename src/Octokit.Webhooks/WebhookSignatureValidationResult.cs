namespace Octokit.Webhooks;

/// <summary>
/// The result of validating a GitHub webhook signature.
/// </summary>
[PublicAPI]
public enum WebhookSignatureValidationResult
{
    /// <summary>
    /// The signature is valid, or no signature was expected or provided.
    /// </summary>
    Valid,

    /// <summary>
    /// The payload was not signed, but a secret is configured and a signature was expected.
    /// </summary>
    MissingSignature,

    /// <summary>
    /// The payload was signed, but no secret is configured to verify against.
    /// </summary>
    MissingSecret,

    /// <summary>
    /// The payload was signed and a secret is configured, but the signature does not match.
    /// </summary>
    SignatureMismatch,
}
