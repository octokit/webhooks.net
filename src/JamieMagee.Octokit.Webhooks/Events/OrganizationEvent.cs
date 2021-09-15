namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Organization)]
    [JsonConverter(typeof(WebhookConverter<OrganizationEvent>))]
    public abstract record OrganizationEvent : WebhookEvent
    {
    }
}
