namespace Octokit.Webhooks.Events.Sponsorship
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.SponsorshipEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(SponsorshipActionValue.Edited)]
    public sealed record SponsorshipEditedEvent : SponsorshipEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SponsorshipAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
