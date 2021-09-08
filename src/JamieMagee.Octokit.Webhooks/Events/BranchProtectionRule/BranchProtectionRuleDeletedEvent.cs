namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;

    public sealed record BranchProtectionRuleDeletedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "deleted";
    }
}
