namespace Octokit.Webhooks.Events.Repository;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Archived)]
public sealed record RepositoryArchivedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Archived;
}