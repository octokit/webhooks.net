namespace Octokit.Webhooks.Models.SecurityAndAnalysisEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("from")]
    public required ChangesFrom From { get; init; }
}
