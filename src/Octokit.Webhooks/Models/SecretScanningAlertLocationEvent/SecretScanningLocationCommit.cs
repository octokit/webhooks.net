namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationCommit
{
    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("start_line")]
    public long StartLine { get; init; }

    [JsonPropertyName("end_line")]
    public long EndLine { get; init; }

    [JsonPropertyName("start_column")]
    public long StartColumn { get; init; }

    [JsonPropertyName("end_column")]
    public long EndColumn { get; init; }

    [JsonPropertyName("blob_sha")]
    public required string BlobSha { get; init; }

    [JsonPropertyName("blob_url")]
    public required string BlobUrl { get; init; }

    [JsonPropertyName("commit_sha")]
    public required string CommitSha { get; init; }

    [JsonPropertyName("commit_url")]
    public required string CommitUrl { get; init; }
}
