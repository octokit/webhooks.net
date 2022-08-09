namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record AlertInstanceMessage
{
    [JsonPropertyName("text")]
    public string? Text { get; init; }
}
