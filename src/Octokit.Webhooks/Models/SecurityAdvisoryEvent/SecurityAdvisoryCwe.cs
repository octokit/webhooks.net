namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisoryCwe
{
    [JsonPropertyName("cwe_id")]
    public required string CweId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
