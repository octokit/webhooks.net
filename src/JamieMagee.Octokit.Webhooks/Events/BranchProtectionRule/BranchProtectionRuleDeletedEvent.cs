namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;

    [WebhookActionType(BranchProtectionRuleActionValue.Deleted)]
    public sealed record BranchProtectionRuleDeletedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => BranchProtectionRuleAction.Deleted;
    }
}
