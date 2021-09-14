namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;

    public sealed record Changes
    {
        [JsonPropertyName("privacy_level")]
        public ChangesPrivacyLevel? PrivacyLevel { get; init; }

        [JsonPropertyName("privacy_level")]
        public ChangesTier? Tier { get; init; }
    }
}
