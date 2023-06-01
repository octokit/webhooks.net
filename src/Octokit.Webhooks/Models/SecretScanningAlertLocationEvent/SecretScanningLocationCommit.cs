namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationCommit
{
    [JsonPropertyName("path")]
    public string Path { get; init; } = null!;

    [JsonPropertyName("start_line")]
    public long StartLine { get; init; }

    [JsonPropertyName("end_line")]
    public long EndLine { get; init; }

    [JsonPropertyName("start_column")]
    public long StartColumn { get; init; }

    [JsonPropertyName("end_column")]
    public long EndColumn { get; init; }

    [JsonPropertyName("blob_sha")]
    public string BlobSha { get; init; } = null!;

    [JsonPropertyName("blob_url")]
    public string BlobUrl { get; init; } = null!;

    [JsonPropertyName("commit_sha")]
    public string CommitSha { get; init; } = null!;

    [JsonPropertyName("commit_url")]
    public string CommitUrl { get; init; } = null!;
}
