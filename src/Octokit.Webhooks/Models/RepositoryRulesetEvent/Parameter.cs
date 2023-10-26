namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Parameter
{
    [JsonPropertyName("update_allows_fetch_and_merge")]
    public bool UpdateAllowsFetchAndMerge { get; init; }
}
