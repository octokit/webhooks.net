namespace Octokit.Webhooks.Events.IssueDependencies;

[PublicAPI]
[WebhookActionType(IssueDependenciesActionValue.BlockingRemoved)]
public sealed record IssueDependenciesBlockingRemovedEvent : IssueDependenciesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueDependenciesAction.BlockingRemoved;

    [JsonPropertyName("blocked_issue_repo")]
    public Models.Repository? BlockedIssueRepo { get; init; }
}
