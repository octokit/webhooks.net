namespace Octokit.Webhooks.Events.DeploymentProtectionRule;

[PublicAPI]
public sealed record DeploymentProtectionRuleAction : WebhookEventAction
{
    public static readonly DeploymentProtectionRuleAction Requested = new(DeploymentProtectionRuleActionValue.Requested);

    private DeploymentProtectionRuleAction(string value)
        : base(value)
    {
    }
}
