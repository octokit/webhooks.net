namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertIdentifier
{
    [JsonPropertyName("value")]
    public required string Value { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
