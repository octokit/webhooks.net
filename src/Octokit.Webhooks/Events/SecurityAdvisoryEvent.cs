namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.SecurityAdvisory)]
    [JsonConverter(typeof(WebhookConverter<SecurityAdvisoryEvent>))]
    public abstract record SecurityAdvisoryEvent : WebhookEvent
    {
        [JsonPropertyName("security_advisory")]
        public Models.SecurityAdvisoryEvent.SecurityAdvisory SecurityAdvisory { get; init; } = null!;
    }
}
