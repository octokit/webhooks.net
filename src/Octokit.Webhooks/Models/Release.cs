namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Release
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("assets_url")]
    public required string AssetsUrl { get; init; }

    [JsonPropertyName("upload_url")]
    public required string UploadUrl { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("tag_name")]
    public required string TagName { get; init; }

    [JsonPropertyName("target_commitish")]
    public required string TargetCommitish { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("draft")]
    public bool Draft { get; init; }

    [JsonPropertyName("author")]
    public required User Author { get; init; }

    [JsonPropertyName("prerelease")]
    public bool Prerelease { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("published_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? PublishedAt { get; init; }

    [JsonPropertyName("assets")]
    public required IReadOnlyList<ReleaseAsset> Assets { get; init; }

    [JsonPropertyName("tarball_url")]
    public string? TarballUrl { get; init; }

    [JsonPropertyName("zipball_url")]
    public string? ZipballUrl { get; init; }

    [JsonPropertyName("body")]
    public required string Body { get; init; }

    [JsonPropertyName("mentions_count")]
    public long? MentionsCount { get; init; }

    [JsonPropertyName("reactions")]
    public Reactions? Reactions { get; init; }

    [JsonPropertyName("discussion_url")]
    public string? DiscussionUrl { get; init; }
}
