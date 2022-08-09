namespace Octokit.Webhooks.Events.PullRequestReviewThread;

[PublicAPI]
[WebhookActionType(PullRequestReviewThreadActionValue.Unresolved)]
public sealed record PullRequestReviewThreadUnresolvedEvent : PullRequestReviewThreadEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewThreadActionValue.Unresolved;
}
