namespace Octokit.Webhooks.Events.Installation;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Suspend)]
public sealed record InstallationSuspendEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Suspend;
}
