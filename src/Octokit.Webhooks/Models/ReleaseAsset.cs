namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ReleaseAsset
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("browser_download_url")]
    public required string BrowserDownloadUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("label")]
    public string? Label { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<ReleaseAssetState>))]
    public required StringEnum<ReleaseAssetState> State { get; init; }

    [JsonPropertyName("content_type")]
    public required string ContentType { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }

    [JsonPropertyName("download_count")]
    public long DownloadCount { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("uploader")]
    public User? Uploader { get; init; }
}
