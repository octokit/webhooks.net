namespace Octokit.Webhooks.Events.Repository;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Unarchived)]
public sealed record RepositoryUnarchivedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Unarchived;
}
