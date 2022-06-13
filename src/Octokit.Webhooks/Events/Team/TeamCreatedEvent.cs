namespace Octokit.Webhooks.Events.Team;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(TeamActionValue.Created)]
public sealed record TeamCreatedEvent : TeamEvent
{
    [JsonPropertyName("action")]
    public override string Action => TeamAction.Created;
}