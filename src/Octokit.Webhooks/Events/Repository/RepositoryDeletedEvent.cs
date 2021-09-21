namespace Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryActionValue.Deleted)]
    public sealed record RepositoryDeletedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Deleted;
    }
}
