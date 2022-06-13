namespace Octokit.Webhooks.Events.DeployKey;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DeployKeyActionValue.Deleted)]
public sealed record DeployKeyDeletedEvent : DeployKeyEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeployKeyAction.Deleted;
}