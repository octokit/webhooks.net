namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record ChangesPrivacyLevel
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
