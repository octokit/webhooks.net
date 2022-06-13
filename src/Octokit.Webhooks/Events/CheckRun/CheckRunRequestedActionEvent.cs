namespace Octokit.Webhooks.Events.CheckRun;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.RequestedAction)]
public sealed record CheckRunRequestedActionEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.RequestedAction;
}