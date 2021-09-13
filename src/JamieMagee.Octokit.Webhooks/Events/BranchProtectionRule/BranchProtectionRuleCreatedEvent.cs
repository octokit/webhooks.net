namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;

    [WebhookActionType(BranchProtectionRuleActionValue.Created)]
    public sealed record BranchProtectionRuleCreatedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => BranchProtectionRuleAction.Created;
    }
}
