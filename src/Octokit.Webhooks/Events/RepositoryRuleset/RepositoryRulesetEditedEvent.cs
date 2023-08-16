namespace Octokit.Webhooks.Events.RepositoryRuleset;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Edited)]
public record RepositoryRulesetEditedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Edited;
}
