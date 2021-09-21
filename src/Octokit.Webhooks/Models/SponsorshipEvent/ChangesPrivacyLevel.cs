namespace Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesPrivacyLevel
    {
        [JsonPropertyName("from")]
        public string From { get; init; } = null!;
    }
}
