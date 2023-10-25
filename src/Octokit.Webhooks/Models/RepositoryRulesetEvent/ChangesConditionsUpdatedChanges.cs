namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record ChangesConditionsUpdatedChanges
{
    [JsonPropertyName("condition_type")]
    public ChangesFrom? ConditionType { get; init; }

    [JsonPropertyName("target_type")]
    public ChangesFrom? Target { get; init; }

    [JsonPropertyName("include")]
    public ChangesFromArray? Include { get; init; }

    [JsonPropertyName("exclude")]
    public ChangesFromArray? Exclude { get; init; }
}
