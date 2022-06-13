namespace Octokit.Webhooks.Events.BranchProtectionRule;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Created)]
public sealed record BranchProtectionRuleCreatedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Created;
}