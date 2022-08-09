namespace Octokit.Webhooks.Events.BranchProtectionRule;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Edited)]
public sealed record BranchProtectionRuleEditedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Edited;
}
