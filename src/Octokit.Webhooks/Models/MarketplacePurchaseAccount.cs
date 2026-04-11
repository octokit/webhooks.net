namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record MarketplacePurchaseAccount
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("login")]
    public required string Login { get; init; }

    [JsonPropertyName("organization_billing_email")]
    public required string OrganizationBillingEmail { get; init; }
}
