namespace Octokit.Webhooks.Events.Release;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ReleaseActionValue.Published)]
public sealed record ReleasePublishedEvent : ReleaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => ReleaseAction.Published;
}
