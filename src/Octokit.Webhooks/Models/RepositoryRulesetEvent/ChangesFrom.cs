namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record ChangesFrom
{
    [JsonPropertyName("from")]
    public string? From { get; init; }
}
