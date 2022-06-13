namespace Octokit.Webhooks.Events.Release;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Created)]
public sealed record ReleaseCreatedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Created;
}
