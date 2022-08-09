namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.ReviewRequested)]
public sealed record PullRequestReviewRequestedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.ReviewRequested;

    [JsonPropertyName("requested_reviewer")]
    public User? RequestedReviewer { get; init; }

    [JsonPropertyName("requested_team")]
    public Team? RequestedTeam { get; init; }
}
