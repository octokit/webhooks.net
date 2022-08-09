namespace Octokit.Webhooks.Events.PullRequestReview;

[PublicAPI]
[WebhookActionType(PullRequestReviewActionValue.Submitted)]
public sealed record PullRequestReviewSubmittedEvent : PullRequestReviewEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewAction.Submitted;
}
