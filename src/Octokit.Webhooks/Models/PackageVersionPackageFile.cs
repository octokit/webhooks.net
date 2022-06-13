namespace Octokit.Webhooks.Models;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record PackageVersionPackageFile
{
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

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
    public long Size { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}