namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitDetailsTree
{
    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
