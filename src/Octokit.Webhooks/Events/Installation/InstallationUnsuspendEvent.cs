namespace Octokit.Webhooks.Events.Installation;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(InstallationActionValue.Unsuspend)]
public sealed record InstallationUnsuspendEvent : InstallationEvent
{
    [JsonPropertyName("action")]
    public override string Action => InstallationAction.Unsuspend;
}