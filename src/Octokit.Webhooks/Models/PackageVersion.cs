namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PackageVersion
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("version")]
    public required string Version { get; init; }

    [JsonPropertyName("summary")]
    public required string Summary { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("body")]
    public JsonElement? Body { get; init; }

    [JsonPropertyName("body_html")]
    public string? BodyHtml { get; init; }

    [JsonPropertyName("release")]
    public PackageVersionRelease? Release { get; init; }

    [JsonPropertyName("manifest")]
    public string? Manifest { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("tag_name")]
    public string? TagName { get; init; }

    [JsonPropertyName("target_commitish")]
    public string? TargetCommitish { get; init; }

    [JsonPropertyName("target_oid")]
    public string? TargetOid { get; init; }

    [JsonPropertyName("draft")]
    public bool? Draft { get; init; }

    [JsonPropertyName("prerelease")]
    public bool? Prerelease { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }

    [JsonPropertyName("metadata")]
    public required IReadOnlyList<JsonElement> Metadata { get; init; }

    [JsonPropertyName("container_metadata")]
    public ContainerMetadata? ContainerMetadata { get; init; }

    [JsonPropertyName("docker_metadata")]
    public IReadOnlyList<JsonElement>? DockerMetadata { get; init; }

    [JsonPropertyName("npm_metadata")]
    public IDictionary<string, JsonElement>? NpmMetadata { get; init; }

    [JsonPropertyName("nuget_metadata")]
    public IReadOnlyList<PackageVersionNugetMetadata>? NugetMetadata { get; init; }

    [JsonPropertyName("rubygems_metadata")]
    public IDictionary<string, JsonElement>? RubygemsMetadata { get; init; }

    [JsonPropertyName("package_files")]
    public required IReadOnlyList<PackageVersionPackageFile> PackageFiles { get; init; }

    [JsonPropertyName("package_url")]
    public string? PackageUrl { get; init; }

    [JsonPropertyName("author")]
    public User? Author { get; init; }

    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; init; }

    [JsonPropertyName("installation_command")]
    public required string InstallationCommand { get; init; }
}
