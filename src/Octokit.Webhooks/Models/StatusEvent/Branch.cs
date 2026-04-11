namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record Branch
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("commit")]
    public required BranchCommit Commit { get; init; }

    [JsonPropertyName("protected")]
    public bool Protected { get; init; }
}
