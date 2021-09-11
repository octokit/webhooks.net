namespace JamieMagee.Octokit.Webhooks.Events.Sponsorship
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record SponsorshipCreatedEvent : SponsorshipEvent
    {
        [JsonPropertyName("action")]
        public override string Action => SponsorshipAction.Created;
    }
}
