namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.SecretScanningAlert)]
    [JsonConverter(typeof(WebhookConverter<SecretScanningAlertEvent>))]
    public abstract record SecretScanningAlertEvent : WebhookEvent
    {
    }
}
