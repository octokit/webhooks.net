namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCwe
{
    [JsonPropertyName("cwe_id")]
    public required string CweId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
