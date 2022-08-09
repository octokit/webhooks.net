namespace Octokit.Webhooks.Events.Sponsorship;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.Created)]
public sealed record SponsorshipCreatedEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.Created;
}
