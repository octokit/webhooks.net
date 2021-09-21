namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Watch)]
    [JsonConverter(typeof(WebhookConverter<WatchEvent>))]
    public abstract record WatchEvent : WebhookEvent;
}
