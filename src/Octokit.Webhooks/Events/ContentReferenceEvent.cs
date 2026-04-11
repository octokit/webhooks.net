namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ContentReference)]
[JsonConverter(typeof(WebhookConverter<ContentReferenceEvent>))]
public abstract record ContentReferenceEvent : WebhookEvent
{
    [JsonPropertyName("content_reference")]
    public required Models.ContentReferenceEvent.ContentReference ContentReference { get; init; }
}
