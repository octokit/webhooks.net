namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

public sealed record ChangesConditions
{
    [JsonPropertyName("added")]
    public IReadOnlyCollection<Conditions>? Added { get; init; }

    [JsonPropertyName("deleted")]
    public IReadOnlyCollection<Conditions>? Deleted { get; init; }

    [JsonPropertyName("updated")]
    public IReadOnlyCollection<ChangesConditionsUpdated>? Updated { get; init; }
}
