namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Label)]
    [JsonConverter(typeof(WebhookConverter<LabelEvent>))]
    public abstract record LabelEvent : WebhookEvent
    {
        [JsonPropertyName("label")]
        public Models.Label Label { get; init; } = null!;
    }
}
