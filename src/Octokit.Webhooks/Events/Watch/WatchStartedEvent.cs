namespace Octokit.Webhooks.Events.Watch;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(WatchActionValue.Started)]
public sealed record WatchStartedEvent : WatchEvent
{
    [JsonPropertyName("action")]
    public override string Action => WatchAction.Started;
}
