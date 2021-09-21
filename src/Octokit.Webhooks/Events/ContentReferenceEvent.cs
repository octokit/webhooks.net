namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.ContentReference)]
    [JsonConverter(typeof(WebhookConverter<ContentReferenceEvent>))]
    public abstract record ContentReferenceEvent : WebhookEvent
    {
        [JsonPropertyName("content_reference")]
        public Models.ContentReferenceEvent.ContentReference ContentReference { get; init; } = null!;
    }
}
