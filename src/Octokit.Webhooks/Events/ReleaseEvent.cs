namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Release)]
    [JsonConverter(typeof(WebhookConverter<ReleaseEvent>))]
    public abstract record ReleaseEvent : WebhookEvent
    {
        [JsonPropertyName("release")]
        public Models.Release Release { get; init; } = null!;
    }
}
