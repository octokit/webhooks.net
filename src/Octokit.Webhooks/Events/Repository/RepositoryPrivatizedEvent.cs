namespace Octokit.Webhooks.Events.Repository;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Privatized)]
public sealed record RepositoryPrivatizedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Privatized;
}
