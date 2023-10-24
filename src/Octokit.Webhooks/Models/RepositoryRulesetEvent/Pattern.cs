namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Pattern
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
