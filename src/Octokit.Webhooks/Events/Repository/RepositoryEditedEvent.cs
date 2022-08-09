namespace Octokit.Webhooks.Events.Repository;

using Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Edited)]
public sealed record RepositoryEditedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
