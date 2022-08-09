namespace Octokit.Webhooks.Events.Repository;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Created)]
public sealed record RepositoryCreatedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Created;
}
