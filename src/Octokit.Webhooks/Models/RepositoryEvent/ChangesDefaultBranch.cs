namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesDefaultBranch
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
