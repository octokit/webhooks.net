namespace Octokit.Webhooks.Models.SecurityAndAnalysisEvent;

[PublicAPI]
public sealed record SecurityFeature
{
    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
