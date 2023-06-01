namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.SecretScanningAlertEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecretScanningAlertLocation)]
[JsonConverter(typeof(WebhookConverter<SecretScanningAlertLocationEvent>))]
public abstract record SecretScanningAlertLocationEvent : WebhookEvent
{
    [JsonPropertyName("alert")]
    public Alert Alert { get; init; } = null!;
}
