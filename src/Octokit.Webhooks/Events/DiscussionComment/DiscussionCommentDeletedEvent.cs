namespace Octokit.Webhooks.Events.DiscussionComment;

[PublicAPI]
[WebhookActionType(DiscussionCommentActionValue.Deleted)]
public sealed record DiscussionCommentDeletedEvent : DiscussionCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionCommentAction.Deleted;
}
