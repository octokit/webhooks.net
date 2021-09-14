namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public record Membership
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("state")]
        public string State { get; init; } = null!;

        [JsonPropertyName("role")]
        public string Role { get; init; } = null!;

        [JsonPropertyName("organization_url")]
        public string OrganizationUrl { get; init; } = null!;

        [JsonPropertyName("user")]
        public User User { get; init; } = null!;
    }
}
