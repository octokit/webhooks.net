namespace Octokit.Webhooks.Models.SecurityAndAnalysisEvent;

[PublicAPI]
public sealed record ChangesFrom
{
    [JsonPropertyName("security_and_analysis")]
    public SecurityAndAnalysis? SecurityAndAnalysis { get; init; }
}
