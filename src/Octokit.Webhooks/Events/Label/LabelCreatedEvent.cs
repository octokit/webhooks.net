namespace Octokit.Webhooks.Events.Label;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(LabelActionValue.Created)]
public sealed record LabelCreatedEvent : LabelEvent
{
    [JsonPropertyName("action")]
    public override string Action => LabelAction.Created;
}