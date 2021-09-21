namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Sponsorship)]
    [JsonConverter(typeof(WebhookConverter<SponsorshipEvent>))]
    public abstract record SponsorshipEvent : WebhookEvent
    {
        [JsonPropertyName("sponsorship")]
        public Models.SponsorshipEvent.Sponsorship Sponsorship { get; init; } = null!;
    }
}
