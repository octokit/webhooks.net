namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCvss
{
    [JsonPropertyName("vector_string")]
    public string? VectorString { get; init; }

    [JsonPropertyName("score")]
    public float? Score { get; init; }
}
