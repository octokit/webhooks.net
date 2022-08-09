namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record MarketplacePurchase
{
    [JsonPropertyName("account")]
    public MarkplacePurchaseAccount Account { get; init; } = null!;

    [JsonPropertyName("billing_cycle")]
    public string BillingCycle { get; init; } = null!;

    [JsonPropertyName("unit_count")]
    public long UnitCount { get; init; }

    [JsonPropertyName("on_free_trial")]
    public bool OnFreeTrial { get; init; }

    [JsonPropertyName("free_trial_ends_on")]
    public string? FreeTrialEndsOn { get; init; }

    [JsonPropertyName("next_billing_date")]
    public string? NextBillingDate { get; init; }

    [JsonPropertyName("plan")]
    public MarkplacePurchasePlan Plan { get; init; } = null!;
}
