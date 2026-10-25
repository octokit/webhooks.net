namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("privacy_level")]
    public ChangesPrivacyLevel? PrivacyLevel { get; init; }

    [JsonPropertyName("tier")]
    public ChangesTier? Tier { get; init; }
}
