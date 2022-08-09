namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Unassigned)]
public sealed record IssuesUnassignedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Unassigned;

    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }
}
