namespace Octokit.Webhooks.Events.PullRequestReview;

[PublicAPI]
[WebhookActionType(PullRequestReviewActionValue.Dismissed)]
public sealed record PullRequestReviewDismissedEvent : PullRequestReviewEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewAction.Dismissed;
}
