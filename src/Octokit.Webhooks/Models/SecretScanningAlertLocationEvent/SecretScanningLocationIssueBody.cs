namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationIssueBody
{
    [JsonPropertyName("issue_body_url")]
    public string IssueBodyUrl { get; init; } = null!;
}
