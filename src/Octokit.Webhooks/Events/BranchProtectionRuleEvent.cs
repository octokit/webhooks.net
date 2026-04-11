namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.BranchProtectionRule)]
[JsonConverter(typeof(WebhookConverter<BranchProtectionRuleEvent>))]
public abstract record BranchProtectionRuleEvent : WebhookEvent
{
    [JsonPropertyName("rule")]
    public required Models.BranchProtectionRule Rule { get; init; }
}
