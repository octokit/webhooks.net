namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.BranchProtectionRule)]
    [JsonConverter(typeof(WebhookConverter<BranchProtectionRuleEvent>))]
    public abstract record BranchProtectionRuleEvent : WebhookEvent
    {
        [JsonPropertyName("rule")]
        public Models.BranchProtectionRule Rule { get; init; } = null!;
    }
}
