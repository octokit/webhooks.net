namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record ChangesTier
{
    [JsonPropertyName("from")]
    public SponsorshipTier From { get; init; } = null!;
}
