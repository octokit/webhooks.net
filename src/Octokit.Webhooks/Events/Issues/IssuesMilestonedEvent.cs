namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Milestoned)]
public sealed record IssuesMilestonedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Milestoned;

    [JsonPropertyName("milestone")]
    public Milestone Milestone { get; init; } = null!;
}
