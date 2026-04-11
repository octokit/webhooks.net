namespace Octokit.Webhooks.Events.BranchProtectionConfiguration;

[PublicAPI]
[WebhookActionType(BranchProtectionConfigurationActionValue.Enabled)]
public sealed record BranchProtectionConfigurationEnabledEvent : BranchProtectionConfigurationEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionConfigurationAction.Enabled;
}
