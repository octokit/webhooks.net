namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Star)]
    [JsonConverter(typeof(WebhookConverter<StarEvent>))]
    public abstract record StarEvent : WebhookEvent
    {
        [JsonPropertyName("starred_at")]
        public string StarredAt { get; init; } = null!;
    }
}
