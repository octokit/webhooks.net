namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationIssueTitle
{
    [JsonPropertyName("issue_title_url")]
    public required string IssueTitleUrl { get; init; }
}
