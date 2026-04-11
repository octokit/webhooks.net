namespace Octokit.Webhooks.Models.SecurityAndAnalysisEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("from")]
    public ChangesFrom From { get; init; } = null!;
}
