namespace JamieMagee.Octokit.Webhooks.Events.Sponsorship
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(SponsorshipActionValue.PendingCancellation)]
    public sealed record SponsorshipPendingCancellationEvent : SponsorshipEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SponsorshipAction.PendingCancellation;

        [JsonPropertyName("effective_date")]
        public string? EffectiveDate { get; init; }
    }
}
