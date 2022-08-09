namespace Octokit.Webhooks.Events.Team;

[PublicAPI]
[WebhookActionType(TeamActionValue.Created)]
public sealed record TeamCreatedEvent : TeamEvent
{
    [JsonPropertyName("action")]
    public override string Action => TeamAction.Created;
}
