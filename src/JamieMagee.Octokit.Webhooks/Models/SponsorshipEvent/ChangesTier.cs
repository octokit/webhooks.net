namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;

    public sealed record ChangesTier
    {
        [JsonPropertyName("from")]
        public SponsorshipTier From { get; init; } = null!;
    }
}
