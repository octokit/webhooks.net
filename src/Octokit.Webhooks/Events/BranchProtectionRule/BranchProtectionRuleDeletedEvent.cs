namespace Octokit.Webhooks.Events.BranchProtectionRule;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Deleted)]
public sealed record BranchProtectionRuleDeletedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Deleted;
}
