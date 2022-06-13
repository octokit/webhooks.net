namespace Octokit.Webhooks.Events.SecurityAdvisory;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Updated)]
public sealed record SecurityAdvisoryUpdatedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Updated;
}
