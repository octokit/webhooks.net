namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record RepoRef
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}