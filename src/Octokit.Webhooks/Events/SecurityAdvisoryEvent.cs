namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecurityAdvisory)]
[JsonConverter(typeof(WebhookConverter<SecurityAdvisoryEvent>))]
public abstract record SecurityAdvisoryEvent : WebhookEvent
{
    [JsonPropertyName("security_advisory")]
    public required Models.SecurityAdvisoryEvent.SecurityAdvisory SecurityAdvisory { get; init; }
}
