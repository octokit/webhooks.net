namespace Octokit.Webhooks.Events.Team;

[PublicAPI]
[WebhookActionType(TeamActionValue.RemovedFromRepository)]
public sealed record TeamRemovedFromRepositoryEvent : TeamEvent
{
    [JsonPropertyName("action")]
    public override string Action => TeamAction.RemovedFromRepository;
}
