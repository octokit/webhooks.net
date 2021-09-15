namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models.SecretScanningAlertEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.SecretScanningAlert)]
    [JsonConverter(typeof(WebhookConverter<SecretScanningAlertEvent>))]
    public abstract record SecretScanningAlertEvent : WebhookEvent
    {
        [JsonPropertyName("alert")]
        public Alert Alert { get; init; } = null!;
    }
}
