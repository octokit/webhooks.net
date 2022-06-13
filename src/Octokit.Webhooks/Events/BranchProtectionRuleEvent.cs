namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.BranchProtectionRule)]
[JsonConverter(typeof(WebhookConverter<BranchProtectionRuleEvent>))]
public abstract record BranchProtectionRuleEvent : WebhookEvent
{
    [JsonPropertyName("rule")]
    public Models.BranchProtectionRule Rule { get; init; } = null!;
}
