namespace Octokit.Webhooks.Events.RepositoryRuleset;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Deleted)]
public sealed record RepositoryRulesetDeletedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Deleted;
}
