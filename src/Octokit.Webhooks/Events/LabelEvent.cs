namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Label)]
[JsonConverter(typeof(WebhookConverter<LabelEvent>))]
public abstract record LabelEvent : WebhookEvent
{
    [JsonPropertyName("label")]
    public Models.Label Label { get; init; } = null!;
}
