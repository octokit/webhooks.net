namespace Octokit.Webhooks.Events.Repository;

using Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Renamed)]
public sealed record RepositoryRenamedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Renamed;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
