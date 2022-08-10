namespace Octokit.Webhooks.Events.BranchProtectionRule;

using Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Edited)]
public sealed record BranchProtectionRuleEditedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Edited;

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}
