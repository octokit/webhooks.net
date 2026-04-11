namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Membership
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonPropertyName("role")]
    public required string Role { get; init; }

    [JsonPropertyName("organization_url")]
    public required string OrganizationUrl { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }
}
