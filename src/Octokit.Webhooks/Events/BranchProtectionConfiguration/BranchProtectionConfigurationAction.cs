namespace Octokit.Webhooks.Events.BranchProtectionConfiguration;

[PublicAPI]
public sealed record BranchProtectionConfigurationAction : WebhookEventAction
{
    public static readonly BranchProtectionConfigurationAction Disabled = new(BranchProtectionConfigurationActionValue.Disabled);

    public static readonly BranchProtectionConfigurationAction Enabled = new(BranchProtectionConfigurationActionValue.Enabled);

    private BranchProtectionConfigurationAction(string value)
        : base(value)
    {
    }
}
