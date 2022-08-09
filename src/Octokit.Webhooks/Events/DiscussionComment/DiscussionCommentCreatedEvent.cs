namespace Octokit.Webhooks.Events.DiscussionComment;

[PublicAPI]
[WebhookActionType(DiscussionCommentActionValue.Created)]
public sealed record DiscussionCommentCreatedEvent : DiscussionCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionCommentAction.Created;
}
