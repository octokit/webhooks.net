namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PackageRegistry
{
    [JsonPropertyName("about_url")]
    public required string AboutUrl { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("vendor")]
    public required string Vendor { get; init; }
}
