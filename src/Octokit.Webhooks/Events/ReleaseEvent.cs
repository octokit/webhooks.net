namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Release)]
[JsonConverter(typeof(WebhookConverter<ReleaseEvent>))]
public abstract record ReleaseEvent : WebhookEvent
{
    [JsonPropertyName("release")]
    public Models.Release Release { get; init; } = null!;
}
