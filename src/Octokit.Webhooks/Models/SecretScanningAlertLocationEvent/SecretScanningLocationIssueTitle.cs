namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocationIssueTitle
{
    [JsonPropertyName("issue_title_url")]
    public string IssueTitleUrl { get; init; } = null!;
}
