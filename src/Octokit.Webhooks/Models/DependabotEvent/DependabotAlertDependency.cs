namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertDependency
{
    [JsonPropertyName("package")]
    public DependabotAlertPackage Package { get; init; } = null!;

    [JsonPropertyName("manifest_path")]
    public string ManifestPath { get; init; } = null!;

    [JsonPropertyName("scope")]
    public DependabotAlertDependencyScope? Scope { get; init; }
}
