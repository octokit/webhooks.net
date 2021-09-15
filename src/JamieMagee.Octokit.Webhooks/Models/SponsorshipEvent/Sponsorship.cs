namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Sponsorship
    {
        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("sponsorable")]
        public User Sponsorable { get; init; } = null!;

        [JsonPropertyName("sponsor")]
        public User Sponsor { get; init; } = null!;

        [JsonPropertyName("privacy_level")]
        public string PrivacyLevel { get; init; } = null!;

        [JsonPropertyName("tier")]
        public SponsorshipTier Tier { get; init; } = null!;
    }
}
