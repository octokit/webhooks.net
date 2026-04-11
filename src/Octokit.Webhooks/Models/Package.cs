namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Package
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("namespace")]
    public required string Namespace { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("ecosystem")]
    public required string Ecosystem { get; init; }

    [JsonPropertyName("package_type")]
    [JsonConverter(typeof(StringEnumConverter<PackageType>))]
    public required StringEnum<PackageType> PackageType { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("owner")]
    public required User Owner { get; init; }

    [JsonPropertyName("package_version")]
    public PackageVersion? PackageVersion { get; init; }

    [JsonPropertyName("registry")]
    public required PackageRegistry Registry { get; init; }
}
