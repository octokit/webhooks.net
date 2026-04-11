namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertPackage
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("ecosystem")]
    public required string Ecosystem { get; init; }
}
