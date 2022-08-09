namespace Octokit.Webhooks.Models.RepositoryEvent;

[PublicAPI]
public sealed record ChangesOwnerFrom
{
    [JsonPropertyName("user")]
    public User? User { get; init; }
}
