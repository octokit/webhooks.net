namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record NonFastForward
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
