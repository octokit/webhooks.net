namespace Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryActionValue.Unarchived)]
    public sealed record RepositoryUnarchivedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Unarchived;
    }
}
