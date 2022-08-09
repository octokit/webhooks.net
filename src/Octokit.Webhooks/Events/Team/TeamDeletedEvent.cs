namespace Octokit.Webhooks.Events.Team;

[PublicAPI]
[WebhookActionType(TeamActionValue.Deleted)]
public sealed record TeamDeletedEvent : TeamEvent
{
    [JsonPropertyName("action")]
    public override string Action => TeamAction.Deleted;
}
