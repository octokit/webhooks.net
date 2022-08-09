namespace Octokit.Webhooks.Events.Sponsorship;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.Cancelled)]
public sealed record SponsorshipCancelledEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.Cancelled;
}
