namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertCwe
{
    [JsonPropertyName("cwe_id")]
    public required string CweId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
