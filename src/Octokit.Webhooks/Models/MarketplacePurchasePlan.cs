namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record MarketplacePurchasePlan
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("monthly_price_in_cents")]
    public long MonthlyPriceInCents { get; init; }

    [JsonPropertyName("yearly_price_in_cents")]
    public long YearlyPriceInCents { get; init; }

    [JsonPropertyName("price_model")]
    public required string PriceModel { get; init; }

    [JsonPropertyName("has_free_trial")]
    public bool HasFreeTrial { get; init; }

    [JsonPropertyName("unit_name")]
    public string? UnitName { get; init; }

    [JsonPropertyName("bullets")]
    public required IReadOnlyList<string> Bullets { get; init; }
}
