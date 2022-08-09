namespace Octokit.Webhooks.Events.Installation;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Created)]
public sealed record InstallationCreatedEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Created;
}
