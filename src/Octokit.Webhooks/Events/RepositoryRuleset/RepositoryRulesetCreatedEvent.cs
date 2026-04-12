namespace Octokit.Webhooks.Events.RepositoryRuleset;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Created)]
public sealed record RepositoryRulesetCreatedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Created;
}
