namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Sponsorship)]
    [JsonConverter(typeof(WebhookConverter<SponsorshipEvent>))]
    public abstract record SponsorshipEvent : WebhookEvent
    {
    }
}
