namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Release)]
    [JsonConverter(typeof(WebhookConverter<ReleaseEvent>))]
    public abstract record ReleaseEvent : WebhookEvent
    {
        [JsonPropertyName("release")]
        public Models.Release Release { get; init; } = null!;
    }
}
