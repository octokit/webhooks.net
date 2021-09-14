namespace JamieMagee.Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.RepositoryEvent;

    [WebhookActionType(RepositoryActionValue.Transferred)]
    public sealed record RepositoryTransferredEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Transferred;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
