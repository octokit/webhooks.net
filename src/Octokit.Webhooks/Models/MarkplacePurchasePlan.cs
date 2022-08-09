namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record MarkplacePurchasePlan
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("monthly_price_in_cents")]
    public long MonthlyPriceInCents { get; init; }

    [JsonPropertyName("yearly_price_in_cents")]
    public long YearlyPriceInCents { get; init; }

    [JsonPropertyName("price_model")]
    public string PriceModel { get; init; } = null!;

    [JsonPropertyName("has_free_trial")]
    public bool HasFreeTrial { get; init; }

    [JsonPropertyName("unit_name")]
    public string? UnitName { get; init; }

    [JsonPropertyName("bullets")]
    public IEnumerable<string> Bullets { get; init; } = null!;
}
