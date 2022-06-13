namespace Octokit.Webhooks.Events.SecurityAdvisory;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SecurityAdvisoryActionValue.Published)]
public sealed record SecurityAdvisoryPublishedEvent : SecurityAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecurityAdvisoryAction.Published;
}