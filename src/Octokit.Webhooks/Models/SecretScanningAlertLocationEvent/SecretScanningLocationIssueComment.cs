namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationIssueComment
{
    [JsonPropertyName("issue_comment_url")]
    public string IssueCommentUrl { get; init; } = null!;
}
