namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisoryCwe
{
    [JsonPropertyName("cwe_id")]
    public string CweId { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}
