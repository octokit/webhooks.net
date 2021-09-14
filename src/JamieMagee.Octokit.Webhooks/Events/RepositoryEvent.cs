namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Repository)]
    [JsonConverter(typeof(WebhookConverter<RepositoryEvent>))]
    public abstract record RepositoryEvent : WebhookEvent
    {
        [JsonPropertyName("repository")]
        public Models.Repository Repository { get; init; } = null!;
    }
}
