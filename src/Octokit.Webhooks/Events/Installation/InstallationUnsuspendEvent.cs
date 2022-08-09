namespace Octokit.Webhooks.Events.Installation;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Unsuspend)]
public sealed record InstallationUnsuspendEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Unsuspend;
}
