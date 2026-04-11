namespace Octokit.Webhooks.Events.PullRequest;

using Milestone = Octokit.Webhooks.Models.Milestone;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Demilestoned)]
public sealed record PullRequestDemilestonedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Demilestoned;

    [JsonPropertyName("milestone")]
    public required Milestone Milestone { get; init; }
}
