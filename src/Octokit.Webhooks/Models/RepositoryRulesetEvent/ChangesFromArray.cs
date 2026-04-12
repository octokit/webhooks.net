namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record ChangesFromArray
{
    [JsonPropertyName("from")]
    public string[]? From { get; init; }
}
