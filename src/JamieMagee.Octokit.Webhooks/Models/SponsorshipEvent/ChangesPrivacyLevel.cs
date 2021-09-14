namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesPrivacyLevel
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
