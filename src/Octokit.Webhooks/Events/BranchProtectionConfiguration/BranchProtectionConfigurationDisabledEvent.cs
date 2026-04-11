namespace Octokit.Webhooks.Events.BranchProtectionConfiguration;

[PublicAPI]
[WebhookActionType(BranchProtectionConfigurationActionValue.Disabled)]
public sealed record BranchProtectionConfigurationDisabledEvent : BranchProtectionConfigurationEvent
{
    [JsonPropertyName("action")]
    public override string Action => BranchProtectionConfigurationAction.Disabled;
}
