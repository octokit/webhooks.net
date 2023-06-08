namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertDependency
{
    [JsonPropertyName("package")]
    public DependabotAlertPackage Package { get; init; } = null!;

    [JsonPropertyName("manifest_path")]
    public string ManifestPath { get; init; } = null!;

    [JsonPropertyName("scope")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertDependencyScope>))]
    public StringEnum<DependabotAlertDependencyScope>? Scope { get; init; }
}
