namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredLinearHistory
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
