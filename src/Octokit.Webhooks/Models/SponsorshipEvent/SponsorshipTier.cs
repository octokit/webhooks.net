namespace Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
public sealed record SponsorshipTier
{
    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("monthly_price_in_cents")]
    public long MonthlyPriceInCents { get; init; }

    [JsonPropertyName("monthly_price_in_dollars")]
    public long MonthlyPriceInDollars { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("is_one_time")]
    public bool IsOneTime { get; init; }

    [JsonPropertyName("is_custom_amount")]
    public bool IsCustomAmount { get; init; }

    [JsonIgnore]
    [Obsolete("The property name is misspelled. Use IsCustomAmount instead.")]
    public bool IsCustomAmmount { get => this.IsCustomAmount; init => this.IsCustomAmount = value; }
}
