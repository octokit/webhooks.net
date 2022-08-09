namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record Branch
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("commit")]
    public BranchCommit Commit { get; init; } = null!;

    [JsonPropertyName("protected")]
    public bool Protected { get; init; }
}
