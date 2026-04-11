namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesRepositoryName
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
