namespace Octokit.Webhooks.Events.RepositoryRuleset;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Deleted)]
public record RepositoryRulesetDeletedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Deleted;
}
