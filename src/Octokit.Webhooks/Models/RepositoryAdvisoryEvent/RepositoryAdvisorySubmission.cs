namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisorySubmission
{
    [JsonPropertyName("accepted")]
    public bool Accepted { get; init; }
}
