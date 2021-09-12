namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record BranchProtectionRuleCreatedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => BranchProtectionRuleAction.Created;
    }
}
