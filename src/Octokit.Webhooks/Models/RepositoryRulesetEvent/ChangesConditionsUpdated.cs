namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record ChangesConditionsUpdated
{
    [JsonPropertyName("condition")]
    public Conditions? Condition { get; init; }

    [JsonPropertyName("changes")]
    public ChangesConditionsUpdatedChanges? Changes { get; init; }
}
