namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record PackageVersionRelease
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("tag_name")]
        public string TagName { get; init; } = null!;

        [JsonPropertyName("target_commitish")]
        public string TargetCommitish { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("draft")]
        public bool Draft { get; init; }

        [JsonPropertyName("author")]
        public User Author { get; init; } = null!;

        [JsonPropertyName("prerelease")]
        public bool Prerelease { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("published_at")]
        public string PublishedAt { get; init; } = null!;
    }
}
