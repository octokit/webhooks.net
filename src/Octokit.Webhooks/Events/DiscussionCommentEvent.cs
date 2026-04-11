namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DiscussionComment)]
[JsonConverter(typeof(WebhookConverter<DiscussionCommentEvent>))]
public abstract record DiscussionCommentEvent : WebhookEvent
{
    [JsonPropertyName("comment")]
    public required Models.DiscussionCommentEvent.DiscussionComment Comment { get; init; }

    [JsonPropertyName("discussion")]
    public required Models.Discussion Discussion { get; init; }
}
