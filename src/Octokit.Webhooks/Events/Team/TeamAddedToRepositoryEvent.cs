namespace Octokit.Webhooks.Events.Team;

[PublicAPI]
[WebhookActionType(TeamActionValue.AddedToRepository)]
public sealed record TeamAddedToRepositoryEvent : TeamEvent
{
    [JsonPropertyName("action")]
    public override string Action => TeamAction.AddedToRepository;
}
