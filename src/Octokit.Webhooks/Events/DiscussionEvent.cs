namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Discussion)]
[JsonConverter(typeof(WebhookConverter<DiscussionEvent>))]
public abstract record DiscussionEvent : WebhookEvent
{
    [JsonPropertyName("discussion")]
    public required Models.Discussion Discussion { get; init; }
}
