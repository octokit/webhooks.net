namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.BranchProtectionRule)]
    [JsonConverter(typeof(WebhookConverter<BranchProtectionRuleEvent>))]
    public abstract record BranchProtectionRuleEvent : WebhookEvent
    {
        [JsonPropertyName("rule")]
        public Models.BranchProtectionRule Rule { get; init; } = null!;
    }
}
