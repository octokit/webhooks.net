namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.ContentReference)]
    [JsonConverter(typeof(WebhookConverter<ContentReferenceEvent>))]
    public abstract record ContentReferenceEvent : WebhookEvent
    {
    }
}
