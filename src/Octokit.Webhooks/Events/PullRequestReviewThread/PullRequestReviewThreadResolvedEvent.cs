namespace Octokit.Webhooks.Events.PullRequestReviewThread;

[PublicAPI]
[WebhookActionType(PullRequestReviewThreadActionValue.Resolved)]
public sealed record PullRequestReviewThreadResolvedEvent : PullRequestReviewThreadEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewThreadActionValue.Resolved;
}
