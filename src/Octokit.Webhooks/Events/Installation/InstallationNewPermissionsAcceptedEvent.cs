namespace Octokit.Webhooks.Events.Installation;

[PublicAPI]
[WebhookActionType(InstallationActionValue.NewPermissionsAccepted)]
public sealed record InstallationNewPermissionsAcceptedEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.NewPermissionsAccepted;
}
