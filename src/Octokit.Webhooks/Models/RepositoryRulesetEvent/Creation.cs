namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Creation
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
