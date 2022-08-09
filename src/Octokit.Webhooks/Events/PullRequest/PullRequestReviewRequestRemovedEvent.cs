namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.ReviewRequestRemoved)]
public sealed record PullRequestReviewRequestRemovedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.ReviewRequestRemoved;

    [JsonPropertyName("requested_reviewer")]
    public User? RequestedReviewer { get; init; }

    [JsonPropertyName("requested_team")]
    public Octokit.Webhooks.Models.Team? RequestedTeam { get; init; }
}
