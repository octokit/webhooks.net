namespace Octokit.Webhooks.Events.Sponsorship;

using Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.PendingTierChange)]
public sealed record SponsorshipPendingTierChangeEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.PendingTierChange;

    [JsonPropertyName("changes")]
    public required Changes Changes { get; init; }

    [JsonPropertyName("effective_date")]
    public string? EffectiveDate { get; init; }
}
