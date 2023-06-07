namespace Octokit.Webhooks;

using System.Net;

/// <summary>
/// An exception thrown when validation of a webhook request fails.
/// </summary>
[PublicAPI]
public sealed class WebhookValidationException : Exception
{
    internal WebhookValidationException(WebhookValidationError error)
        : base(GetMessage(error))
    {
        this.StatusCode = HttpStatusCode.BadRequest;  // Always 400 for now.
        this.Error = error;
    }

    /// <summary>Gets the reason for the validation failure.</summary>
    public WebhookValidationError Error { get; }

    /// <summary>Gets the HTTP status code for the validation failure.</summary>
    public HttpStatusCode StatusCode { get; }

    private static string GetMessage(WebhookValidationError error) =>
        error switch
        {
            WebhookValidationError.IncorrectContentType => "Webhook request has incorrect content type.",
            WebhookValidationError.InvalidSignature => "Signature in webhook request does not match the expected signature.",
            WebhookValidationError.UnexpectedSignature => "Webhook request has a signature, but the client is not expecting one.",
            WebhookValidationError.MissingSignature => "Webhook request is missing a signature.",
            _ => throw new ArgumentOutOfRangeException(nameof(error)),
        };
}
