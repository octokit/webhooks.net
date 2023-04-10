namespace Octokit.Webhooks.Events.PullRequest;

using Milestone = Octokit.Webhooks.Models.Milestone;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Milestoned)]
public sealed record PullRequestMilestoned : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Milestoned;

    [JsonPropertyName("milestone")]
    public Milestone Milestone { get; init; } = null!;
}
