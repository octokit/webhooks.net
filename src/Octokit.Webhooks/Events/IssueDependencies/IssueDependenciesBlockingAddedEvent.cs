namespace Octokit.Webhooks.Events.IssueDependencies;

[PublicAPI]
[WebhookActionType(IssueDependenciesActionValue.BlockingAdded)]
public sealed record IssueDependenciesBlockingAddedEvent : IssueDependenciesEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueDependenciesAction.BlockingAdded;

    [JsonPropertyName("blocked_issue_repo")]
    public Models.Repository? BlockedIssueRepo { get; init; }
}
