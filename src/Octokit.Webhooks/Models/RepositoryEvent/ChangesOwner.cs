namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesOwner
{
    [JsonPropertyName("from")]
    public ChangesOwnerFrom? From { get; init; }
}
