namespace Octokit.Webhooks.Events.IssueDependencies;

[PublicAPI]
[WebhookActionType(IssueDependenciesActionValue.BlockedByAdded)]
public sealed record IssueDependenciesBlockedByAddedEvent : IssueDependenciesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueDependenciesAction.BlockedByAdded;

    [JsonPropertyName("blocking_issue_repo")]
    public Models.Repository? BlockingIssueRepo { get; init; }
}
