namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertIdentifier
{
    [JsonPropertyName("value")]
    public string Value { get; init; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;
}
