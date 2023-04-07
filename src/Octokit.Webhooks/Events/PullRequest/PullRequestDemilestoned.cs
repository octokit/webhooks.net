namespace Octokit.Webhooks.Events.PullRequest;

using Milestone = Octokit.Webhooks.Models.Milestone;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Demilestoned)]
public sealed record PullRequestDemilestoned : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Demilestoned;

    [JsonPropertyName("milestone")]
    public Milestone Milestone { get; init; } = null!;
}
