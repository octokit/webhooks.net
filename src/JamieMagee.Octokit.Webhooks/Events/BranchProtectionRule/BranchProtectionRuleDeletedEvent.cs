namespace JamieMagee.Octokit.Webhooks.Events.BranchProtectionRule
{
    using System.Text.Json.Serialization;

    public class BranchProtectionRuleDeletedEvent : BranchProtectionRuleEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "deleted";
    }
}
