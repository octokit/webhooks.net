namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredStatusChecks
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
