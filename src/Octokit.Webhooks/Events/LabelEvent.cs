namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Label)]
    [JsonConverter(typeof(WebhookConverter<LabelEvent>))]
    public abstract record LabelEvent : WebhookEvent
    {
        [JsonPropertyName("label")]
        public Models.Label Label { get; init; } = null!;
    }
}
