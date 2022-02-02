namespace Octokit.Webhooks.Events
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Star)]
    [JsonConverter(typeof(WebhookConverter<StarEvent>))]
    public abstract record StarEvent : WebhookEvent
    {
        [JsonPropertyName("starred_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset StarredAt { get; init; }
    }
}
