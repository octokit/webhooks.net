namespace Octokit.Webhooks.Events.Repository;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Publicized)]
public sealed record RepositoryPublicizedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Publicized;
}
