namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Reactions
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("total_count")]
    public long TotalCount { get; init; }

    [JsonPropertyName("+1")]
    public long PlusOne { get; init; }

    [JsonPropertyName("-1")]
    public long MinusOne { get; init; }

    [JsonPropertyName("laugh")]
    public long Laugh { get; init; }

    [JsonPropertyName("hooray")]
    public long Hooray { get; init; }

    [JsonPropertyName("confused")]
    public long Confused { get; init; }

    [JsonPropertyName("heart")]
    public long Heart { get; init; }

    [JsonPropertyName("rocket")]
    public long Rocket { get; init; }

    [JsonPropertyName("eyes")]
    public long Eyes { get; init; }
}
