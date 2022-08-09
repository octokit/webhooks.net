namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesRepositoryName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
