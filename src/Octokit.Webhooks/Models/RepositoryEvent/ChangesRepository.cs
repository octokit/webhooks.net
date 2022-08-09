namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesRepository
{
    [JsonPropertyName("name")]
    public ChangesRepositoryName? Name { get; init; }
}
