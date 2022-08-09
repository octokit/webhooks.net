namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DiscussionComment)]
[JsonConverter(typeof(WebhookConverter<DiscussionCommentEvent>))]
public abstract record DiscussionCommentEvent : WebhookEvent
{
    [JsonPropertyName("comment")]
    public Models.DiscussionCommentEvent.DiscussionComment Comment { get; init; } = null!;

    [JsonPropertyName("discussion")]
    public Models.Discussion Discussion { get; init; } = null!;
}
