namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Organization)]
    [JsonConverter(typeof(WebhookConverter<OrganizationEvent>))]
    public abstract record OrganizationEvent : WebhookEvent
    {
    }
}
