namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Assigned)]
public sealed record PullRequestAssignedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Assigned;

    [JsonPropertyName("assignee")]
    public User Assignee { get; init; } = null!;
}
