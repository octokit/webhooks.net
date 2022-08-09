namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Demilestoned)]
public sealed record IssuesDemilestonedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Demilestoned;

    [JsonPropertyName("milestone")]
    public Octokit.Webhooks.Models.Milestone Milestone { get; init; } = null!;
}
