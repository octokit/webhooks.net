namespace Octokit.Webhooks.Events.Repository
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(RepositoryActionValue.Privatized)]
    public sealed record RepositoryPrivatizedEvent : RepositoryEvent
    {
        [JsonPropertyName("action")]
        public override string Action => RepositoryAction.Privatized;
    }
}
