namespace Octokit.Webhooks.Events.Installation;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Deleted)]
public sealed record InstallationDeletedEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Deleted;
}
