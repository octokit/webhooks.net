namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredSignatures
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
