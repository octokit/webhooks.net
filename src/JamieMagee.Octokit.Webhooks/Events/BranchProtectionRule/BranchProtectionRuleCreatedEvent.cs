namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public class BranchProtectionRuleCreatedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "created";

        [JsonPropertyName("rule")]
        public BranchProtectionRule Rule { get; set; } = null!;
    }
}
