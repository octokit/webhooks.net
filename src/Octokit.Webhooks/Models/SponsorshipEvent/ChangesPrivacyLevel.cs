namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record ChangesPrivacyLevel
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
