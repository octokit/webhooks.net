namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Repository)]
    [JsonConverter(typeof(WebhookConverter<RepositoryEvent>))]
    public abstract record RepositoryEvent : WebhookEvent
    {
        [JsonPropertyName("repository")]
        public Models.Repository Repository { get; init; } = null!;
    }
}
