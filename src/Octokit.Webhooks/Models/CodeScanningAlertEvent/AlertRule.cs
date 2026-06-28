namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record AlertRule
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<AlertRuleSeverity>))]
    public StringEnum<AlertRuleSeverity>? Severity { get; init; }

    [JsonPropertyName("security_severity_level")]
    public string? SecuritySeverityLevel { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("full_description")]
    public string? FullDescription { get; init; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }

    [JsonPropertyName("help")]
    public string? Help { get; init; }

    [JsonPropertyName("help_uri")]
    public string? HelpUri { get; init; }
}
