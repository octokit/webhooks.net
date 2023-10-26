namespace Octokit.Webhooks.Events.RepositoryRuleset;

using Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
[WebhookActionType(RepositoryRulesetActionValue.Edited)]
public record RepositoryRulesetEditedEvent : RepositoryRulesetEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryRulesetAction.Edited;

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}
