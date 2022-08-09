namespace Octokit.Webhooks.Events.Repository;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Deleted)]
public sealed record RepositoryDeletedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Deleted;
}
