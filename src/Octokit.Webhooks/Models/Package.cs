namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Package
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("namespace")]
    public string Namespace { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("ecosystem")]
    public string Ecosystem { get; init; } = null!;

    [JsonPropertyName("package_type")]
    public PackageType PackageType { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("owner")]
    public User Owner { get; init; } = null!;

    [JsonPropertyName("package_version")]
    public PackageVersion? PackageVersion { get; init; }

    [JsonPropertyName("registry")]
    public PackageRegistry Registry { get; init; } = null!;
}
