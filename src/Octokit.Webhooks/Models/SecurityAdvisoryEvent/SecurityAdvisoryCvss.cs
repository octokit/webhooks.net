namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisoryCvss
{
    [JsonPropertyName("vector_string")]
    public string? VectorString { get; init; }

    [JsonPropertyName("score")]
    public float Score { get; init; }
}
