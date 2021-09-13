namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.CodeScanningAlert)]
    [JsonConverter(typeof(WebhookConverter<CodeScanningAlertEvent>))]
    public abstract record CodeScanningAlertEvent : WebhookEvent
    {
    }
}
