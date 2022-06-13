namespace Octokit.Webhooks.Events.Repository;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
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