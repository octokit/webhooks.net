namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record ChangesTier
{
    [JsonPropertyName("from")]
    public required SponsorshipTier From { get; init; }
}
