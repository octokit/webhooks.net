namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RefName
{
    [JsonPropertyName("include")]
    public IReadOnlyCollection<string>? Include { get; init; }

    [JsonPropertyName("exclude")]
    public IReadOnlyCollection<string>? Exclude { get; init; }
}
