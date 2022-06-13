namespace Octokit.Webhooks.Events.Repository;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(RepositoryActionValue.Publicized)]
public sealed record RepositoryPublicizedEvent : RepositoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAction.Publicized;
}