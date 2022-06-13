namespace Octokit.Webhooks.Events.Installation;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Deleted)]
public sealed record InstallationDeletedEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Deleted;
}