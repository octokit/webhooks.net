namespace Octokit.Webhooks.Events.DeploymentProtectionRule;

[PublicAPI]
[WebhookActionType(DeploymentProtectionRuleActionValue.Requested)]
public sealed record DeploymentProtectionRuleRequestedEvent : DeploymentProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentProtectionRuleAction.Requested;
}
