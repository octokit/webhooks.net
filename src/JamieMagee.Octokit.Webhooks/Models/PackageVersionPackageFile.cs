namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record PackageVersionPackageFile
    {
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("sha256")]
        public string Sha256 { get; init; } = null!;

        [JsonPropertyName("sha1")]
        public string Sha1 { get; init; } = null!;

        [JsonPropertyName("md5")]
        public string Md5 { get; init; } = null!;

        [JsonPropertyName("content_type")]
        public string ContentType { get; init; } = null!;

        [JsonPropertyName("state")]
        public string State { get; init; } = null!;

        [JsonPropertyName("size")]
        public int Size { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;
    }
}
