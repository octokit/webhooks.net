namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record ReleaseAsset
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("browser_download_url")]
        public string BrowserDownloadUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("label")]
        public string? Label { get; init; }

        [JsonPropertyName("state")]
        public ReleaseAssetState State { get; init; }

        [JsonPropertyName("content_type")]
        public string ContentType { get; init; } = null!;

        [JsonPropertyName("size")]
        public int Size { get; init; }

        [JsonPropertyName("download_count")]
        public int DownloadCount { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("uploader")]
        public User? Uploader { get; init; } }
}
