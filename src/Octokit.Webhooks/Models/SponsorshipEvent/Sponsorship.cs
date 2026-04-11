namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record Sponsorship
{
    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("sponsorable")]
    public required User Sponsorable { get; init; }

    [JsonPropertyName("sponsor")]
    public required User Sponsor { get; init; }

    [JsonPropertyName("privacy_level")]
    public required string PrivacyLevel { get; init; }

    [JsonPropertyName("tier")]
    public required SponsorshipTier Tier { get; init; }
}
