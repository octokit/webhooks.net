namespace Octokit.Webhooks.Events.SecurityAdvisory;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Performed)]
public sealed record SecurityAdvisoryPerformedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Performed;
}
