namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record Changes
{
    [JsonPropertyName("name")]
    public ChangesFrom? Name { get; init; }

    [JsonPropertyName("enforcement")]
    public ChangesFrom? Enforcement { get; init; }

    [JsonPropertyName("conditions")]
    public ChangesConditions? Conditions { get; init; }
}
