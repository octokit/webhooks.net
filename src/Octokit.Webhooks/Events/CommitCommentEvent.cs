namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.CommitCommentEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.CommitComment)]
[JsonConverter(typeof(WebhookConverter<CommitCommentEvent>))]
public abstract record CommitCommentEvent : WebhookEvent
{
    [JsonPropertyName("comment")]
    public Comment Comment { get; init; } = null!;
}
