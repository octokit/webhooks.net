namespace Octokit.Webhooks.Events.BranchProtectionRule;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(BranchProtectionRuleActionValue.Edited)]
public sealed record BranchProtectionRuleEditedEvent : BranchProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionRuleAction.Edited;
}
