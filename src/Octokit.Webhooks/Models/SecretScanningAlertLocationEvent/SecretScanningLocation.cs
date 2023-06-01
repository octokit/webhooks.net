namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
public sealed record SecretScanningLocation
{
    [JsonPropertyName("type")]
    public SecretScanningLocationType Type { get; init; }

    // TODO: type union with SecretScanningLocationCommit, SecretScanningLocationIssueBody, etc.
    [JsonPropertyName("details")]
    public dynamic Details { get; init; } = null!;
}
