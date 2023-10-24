namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Deletion
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
