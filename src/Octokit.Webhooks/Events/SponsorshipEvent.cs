namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Sponsorship)]
[JsonConverter(typeof(WebhookConverter<SponsorshipEvent>))]
public abstract record SponsorshipEvent : WebhookEvent
{
    [JsonPropertyName("sponsorship")]
    public required Models.SponsorshipEvent.Sponsorship Sponsorship { get; init; }
}
