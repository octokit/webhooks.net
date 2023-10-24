namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Conditions
{
    [JsonPropertyName("ref_name")]
    public RefName? RefName { get; init; }
}
