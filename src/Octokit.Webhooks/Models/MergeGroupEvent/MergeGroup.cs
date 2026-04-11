namespace Octokit.Webhooks.Models.MergeGroupEvent;

[PublicAPI]
public sealed record MergeGroup
{
    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("head_ref")]
    public required string HeadRef { get; init; }

    [JsonPropertyName("base_ref")]
    public required string BaseRef { get; init; }

    [JsonPropertyName("base_sha")]
    public required string BaseSha { get; init; }

    [JsonPropertyName("head_commit")]
    public required SimpleCommit HeadCommit { get; init; }
}
