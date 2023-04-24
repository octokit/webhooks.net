namespace Octokit.Webhooks.Models.MergeGroupEvent;

[PublicAPI]
public sealed record MergeGroup
{
    [JsonPropertyName("head_sha")]
    public string HeadSha { get; init; } = null!;

    [JsonPropertyName("head_ref")]
    public string HeadRef { get; init; } = null!;

    [JsonPropertyName("base_ref")]
    public string BaseRef { get; init; } = null!;

    [JsonPropertyName("base_sha")]
    public string BaseSha { get; init; } = null!;

    [JsonPropertyName("head_commit")]
    public SimpleCommit HeadCommit { get; init; } = null!;
}
