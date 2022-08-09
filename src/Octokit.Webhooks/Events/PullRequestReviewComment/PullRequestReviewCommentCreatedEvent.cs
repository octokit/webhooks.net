namespace Octokit.Webhooks.Events.PullRequestReviewComment;

[PublicAPI]
[WebhookActionType(PullRequestReviewCommentActionValue.Created)]
public sealed record PullRequestReviewCommentCreatedEvent : PullRequestReviewCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewCommentAction.Created;
}
