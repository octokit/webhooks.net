namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record ChangesFrom
{
    [JsonPropertyName("from")]
    public string? From { get; init; }
}
