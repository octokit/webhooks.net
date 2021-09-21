namespace Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.RepositoryEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryActionValue.Edited)]
    public sealed record RepositoryEditedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
