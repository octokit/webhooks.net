namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public record MarkplacePurchaseAccount
    {
        [JsonPropertyName("type")]
        public string Type { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("login")]
        public string Login { get; init; } = null!;

        [JsonPropertyName("organization_billing_email")]
        public string OrganizationBillingEmail { get; init; } = null!;
    }
}
