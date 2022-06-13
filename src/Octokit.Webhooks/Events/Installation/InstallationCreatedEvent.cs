namespace Octokit.Webhooks.Events.Installation;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Created)]
public sealed record InstallationCreatedEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Created;
}
