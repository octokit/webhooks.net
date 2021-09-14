namespace JamieMagee.Octokit.Webhooks.Models.SponsorshipEvent
{
    using System.Text.Json.Serialization;

    public sealed record SponsorshipTier
    {
        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("monthly_price_in_cents")]
        public int MonthlyPriceInCents { get; init; }

        [JsonPropertyName("monthly_price_in_dollars")]
        public int MonthlyPriceInDollars { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("is_one_time")]
        public bool IsOneTime { get; init; }

        [JsonPropertyName("is_custom_ammount")]
        public bool IsCustomAmmount { get; init; }
    }
}
