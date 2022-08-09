namespace Octokit.Webhooks.Events.BranchProtectionRule;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Created)]
public sealed record BranchProtectionRuleCreatedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Created;
}
