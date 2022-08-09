namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record SponsorshipTier
{
    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("monthly_price_in_cents")]
    public long MonthlyPriceInCents { get; init; }

    [JsonPropertyName("monthly_price_in_dollars")]
    public long MonthlyPriceInDollars { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("is_one_time")]
    public bool IsOneTime { get; init; }

    [JsonPropertyName("is_custom_ammount")]
    public bool IsCustomAmmount { get; init; }
}
