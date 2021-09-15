namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Package
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("namespace")]
        public string Namespace { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("ecosystem")]
        public string Ecosystem { get; init; } = null!;

        [JsonPropertyName("package_type")]
        public string PackageType { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("owner")]
        public User Owner { get; init; } = null!;

        [JsonPropertyName("package_version")]
        public PackageVersion PackageVersion { get; init; } = null!;

        [JsonPropertyName("registry")]
        public PackageRegistry Registry { get; init; } = null!;
    }
}
