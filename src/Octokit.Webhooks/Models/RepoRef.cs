namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record RepoRef
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
