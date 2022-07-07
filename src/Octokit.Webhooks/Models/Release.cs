namespace Octokit.Webhooks.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Release
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("assets_url")]
    public string AssetsUrl { get; init; } = null!;

    [JsonPropertyName("upload_url")]
    public string UploadUrl { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

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
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("published_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? PublishedAt { get; init; }

    [JsonPropertyName("assets")]
    public IEnumerable<ReleaseAsset> Assets { get; init; } = null!;

    [JsonPropertyName("tarball_url")]
    public string? TarballUrl { get; init; }

    [JsonPropertyName("zipball_url")]
    public string? ZipballUrl { get; init; }

    [JsonPropertyName("body")]
    public string Body { get; init; } = null!;

    [JsonPropertyName("mentions_count")]
    public long? MentionsCount { get; init; }

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }

    [JsonPropertyName("discussion_url")]
    public string? DiscussionUrl { get; init; }
}
