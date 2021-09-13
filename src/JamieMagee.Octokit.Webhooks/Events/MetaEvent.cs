namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Meta)]
    [JsonConverter(typeof(WebhookConverter<MetaEvent>))]
    public abstract record MetaEvent : WebhookEvent
    {
    }
}
