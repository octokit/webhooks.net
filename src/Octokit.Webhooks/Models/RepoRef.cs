namespace Octokit.Webhooks.Models;

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
