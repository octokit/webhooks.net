namespace Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.RepositoryEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryActionValue.Transferred)]
    public sealed record RepositoryTransferredEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Transferred;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
