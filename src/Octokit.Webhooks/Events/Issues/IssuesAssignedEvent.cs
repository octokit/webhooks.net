namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
[WebhookActionType(IssuesActionValue.Assigned)]
public sealed record IssuesAssignedEvent : IssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssuesAction.Assigned;

    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }
}
