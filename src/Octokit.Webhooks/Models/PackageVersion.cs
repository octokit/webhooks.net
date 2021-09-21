namespace Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record PackageVersion
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("version")]
        public string Version { get; init; } = null!;

        [JsonPropertyName("summary")]
        public string Summary { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("body")]
        public string Body { get; init; } = null!;

        [JsonPropertyName("body_html")]
        public string BodyHtml { get; init; } = null!;

        [JsonPropertyName("release")]
        public PackageVersionRelease Release { get; init; } = null!;

        [JsonPropertyName("manifest")]
        public string Manifest { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("tag_name")]
        public string TagName { get; init; } = null!;

        [JsonPropertyName("target_commitish")]
        public string TargetCommitish { get; init; } = null!;

        [JsonPropertyName("target_oid")]
        public string TargetOid { get; init; } = null!;

        [JsonPropertyName("draft")]
        public bool Draft { get; init; }

        [JsonPropertyName("prerelease")]
        public bool Prerelease { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("metadata")]
        public IEnumerable<dynamic> Metadata { get; init; } = null!;

        [JsonPropertyName("docker_metadata")]
        public IEnumerable<dynamic> DockerMetadata { get; init; } = null!;

        [JsonPropertyName("package_files")]
        public IEnumerable<PackageVersionPackageFile> PackageFiles { get; init; } = null!;

        [JsonPropertyName("author")]
        public User Author { get; init; } = null!;

        [JsonPropertyName("source_url")]
        public string SourceUrl { get; init; } = null!;

        [JsonPropertyName("installation_command")]
        public string InstallationCommand { get; init; } = null!;
    }
}
