namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ChangesTier
    {
        [JsonPropertyName("from")]
        public SponsorshipTier From { get; init; } = null!;
    }
}
