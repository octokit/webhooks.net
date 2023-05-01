namespace Octokit.Webhooks;

/// <summary>
/// The reason why a webhook request was invalid.
/// </summary>
[PublicAPI]
public enum WebhookValidationError
{
    /// <summary>The "Content-Type" header was missing, or was not "application/json".</summary>
    IncorrectContentType,

    /// <summary>The requst contained a signature, but it did not match the expected signature.</summary>
    InvalidSignature,

    /// <summary>The client was expecting a signature, but the request did not contain one.</summary>
    MissingSignature,

    /// <summary>The request contained a signature, but the client was not expecting one.</summary>
    UnexpectedSignature,
}
