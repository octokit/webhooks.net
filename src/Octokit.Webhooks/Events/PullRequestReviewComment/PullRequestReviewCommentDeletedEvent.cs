namespace Octokit.Webhooks.Events.PullRequestReviewComment;

[PublicAPI]
[WebhookActionType(PullRequestReviewCommentActionValue.Deleted)]
public sealed record PullRequestReviewCommentDeletedEvent : PullRequestReviewCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewCommentAction.Deleted;
}
