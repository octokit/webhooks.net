namespace Octokit.Webhooks.Events.RepositoryRuleset;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Created)]
public record RepositoryRulesetCreatedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Created;
}
