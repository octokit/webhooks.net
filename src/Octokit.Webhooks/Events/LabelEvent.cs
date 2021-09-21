namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Label)]
    [JsonConverter(typeof(WebhookConverter<LabelEvent>))]
    public abstract record LabelEvent : WebhookEvent
    {
        [JsonPropertyName("label")]
        public Models.Label Label { get; init; } = null!;
    }
}
