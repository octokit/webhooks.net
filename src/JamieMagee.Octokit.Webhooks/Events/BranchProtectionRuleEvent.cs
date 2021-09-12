namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;

    public abstract record BranchProtectionRuleEvent : WebhookEvent
    {
        [JsonPropertyName("rule")]
        public Models.BranchProtectionRule Rule { get; init; } = null!;
    }
}
