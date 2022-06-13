namespace Octokit.Webhooks.Models;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record ReleaseAsset
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("browser_download_url")]
    public string BrowserDownloadUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

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
