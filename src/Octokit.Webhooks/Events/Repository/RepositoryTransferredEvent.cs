namespace Octokit.Webhooks.Events.Repository;

using Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Transferred)]
public sealed record RepositoryTransferredEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Transferred;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
