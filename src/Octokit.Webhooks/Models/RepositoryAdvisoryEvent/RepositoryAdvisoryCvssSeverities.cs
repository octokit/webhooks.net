namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCvssSeverities
{
    [JsonPropertyName("cvss_v3")]
    public RepositoryAdvisoryCvss? CvssV3 { get; init; }

    [JsonPropertyName("cvss_v4")]
    public RepositoryAdvisoryCvss? CvssV4 { get; init; }
}
