namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesDefaultBranch
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
