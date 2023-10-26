namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record ChangesFromArray
{
    [JsonPropertyName("from")]
    public string[]? From { get; init; }
}
