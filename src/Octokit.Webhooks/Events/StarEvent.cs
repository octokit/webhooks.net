namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Star)]
[JsonConverter(typeof(WebhookConverter<StarEvent>))]
public abstract record StarEvent : WebhookEvent
{
    [JsonPropertyName("starred_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? StarredAt { get; init; }
}
