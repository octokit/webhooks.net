namespace Octokit.Webhooks.Models.PageBuildEvent;

using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record Build
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("status")]
    public string Status { get; init; } = null!;

    [JsonPropertyName("error")]
    public BuildError Error { get; init; } = null!;

    [JsonPropertyName("pusher")]
    public User Pusher { get; init; } = null!;

    [JsonPropertyName("commit")]
    public string Commit { get; init; } = null!;

    [JsonPropertyName("duration")]
    public long Duration { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
