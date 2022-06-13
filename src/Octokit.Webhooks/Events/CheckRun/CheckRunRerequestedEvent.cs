namespace Octokit.Webhooks.Events.CheckRun;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CheckRunActionValue.Rerequested)]
public sealed record CheckRunRerequestedEvent : CheckRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => CheckRunAction.Rerequested;
}
