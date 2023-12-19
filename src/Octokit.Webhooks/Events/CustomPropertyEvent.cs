namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CustomProperty)]
[JsonConverter(typeof(WebhookConverter<CustomPropertyEvent>))]
public abstract record CustomPropertyEvent : WebhookEvent
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; init; } = null!;
}
