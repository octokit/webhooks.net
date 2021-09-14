namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Watch)]
    [JsonConverter(typeof(WebhookConverter<WatchEvent>))]
    public abstract record WatchEvent : WebhookEvent;
}
