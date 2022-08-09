namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesHomepage
{
    [JsonPropertyName("from")]
    public string? From { get; init; }
}
