namespace Octokit.Webhooks.Events.IssueDependencies;

[PublicAPI]
[WebhookActionType(IssueDependenciesActionValue.BlockedByRemoved)]
public sealed record IssueDependenciesBlockedByRemovedEvent : IssueDependenciesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueDependenciesAction.BlockedByRemoved;

    [JsonPropertyName("blocking_issue_repo")]
    public Models.Repository? BlockingIssueRepo { get; init; }
}
