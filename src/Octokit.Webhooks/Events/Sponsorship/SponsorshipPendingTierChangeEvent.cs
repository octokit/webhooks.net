namespace Octokit.Webhooks.Events.Sponsorship;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.PendingTierChange)]
public sealed record SponsorshipPendingTierChangeEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.PendingTierChange;

    [JsonPropertyName("effective_date")]
    public string? EffectiveDate { get; init; }
}
