namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Sponsorship)]
    [JsonConverter(typeof(WebhookConverter<SponsorshipEvent>))]
    public abstract record SponsorshipEvent : WebhookEvent
    {
        [JsonPropertyName("sponsorship")]
        public Models.SponsorshipEvent.Sponsorship Sponsorship { get; init; } = null!;
    }
}
