namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PackageVersion
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("version")]
    public string Version { get; init; } = null!;

    [JsonPropertyName("summary")]
    public string Summary { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("body")]
    public dynamic? Body { get; init; }

    [JsonPropertyName("body_html")]
    public string? BodyHtml { get; init; }

    [JsonPropertyName("release")]
    public PackageVersionRelease? Release { get; init; }

    [JsonPropertyName("manifest")]
    public string? Manifest { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

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
    public IEnumerable<dynamic> Metadata { get; init; } = null!;

    [JsonPropertyName("container_metadata")]
    public ContainerMetadata? ContainerMetadata { get; init; }

    [JsonPropertyName("docker_metadata")]
    public IEnumerable<dynamic>? DockerMetadata { get; init; }

    [JsonPropertyName("npm_metadata")]
    public IDictionary<string, dynamic>? NpmMetadata { get; init; }

    [JsonPropertyName("nuget_metadata")]
    public IDictionary<string, dynamic>? NugetMetadata { get; init; }

    [JsonPropertyName("rubygems_metadata")]
    public IDictionary<string, dynamic>? RubygemsMetadata { get; init; }

    [JsonPropertyName("package_files")]
    public IEnumerable<PackageVersionPackageFile> PackageFiles { get; init; } = null!;

    [JsonPropertyName("package_url")]
    public string? PackageUrl { get; init; }

    [JsonPropertyName("author")]
    public User? Author { get; init; }

    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; init; }

    [JsonPropertyName("installation_command")]
    public string InstallationCommand { get; init; } = null!;
}
