namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Demilestoned)]
public sealed record IssuesDemilestonedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Demilestoned;

    [JsonPropertyName("milestone")]
    public Milestone Milestone { get; init; } = null!;
}
