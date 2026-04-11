namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationIssueComment
{
    [JsonPropertyName("issue_comment_url")]
    public required string IssueCommentUrl { get; init; }
}
