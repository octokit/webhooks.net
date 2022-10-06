namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertCwe
{
    [JsonPropertyName("cwe_id")]
    public string CweId { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}
