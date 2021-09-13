namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.OrgBlock)]
    [JsonConverter(typeof(WebhookConverter<OrgBlockEvent>))]
    public abstract record OrgBlockEvent : WebhookEvent
    {
    }
}
