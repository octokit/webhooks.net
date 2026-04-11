namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertDependency
{
    [JsonPropertyName("package")]
    public required DependabotAlertPackage Package { get; init; }

    [JsonPropertyName("manifest_path")]
    public required string ManifestPath { get; init; }

    [JsonPropertyName("scope")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertDependencyScope>))]
    public StringEnum<DependabotAlertDependencyScope>? Scope { get; init; }
}
