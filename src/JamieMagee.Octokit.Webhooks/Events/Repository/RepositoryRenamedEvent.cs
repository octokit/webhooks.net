namespace JamieMagee.Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.RepositoryEvent;

    [WebhookActionType(RepositoryActionValue.Renamed)]
    public sealed record RepositoryRenamedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Renamed;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
