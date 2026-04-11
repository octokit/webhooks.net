namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record AlertRule
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<AlertRuleSeverity>))]
    public StringEnum<AlertRuleSeverity>? Severity { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("full_description")]
    public string? FullDescription { get; init; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }

    [JsonPropertyName("help")]
    public string? Help { get; init; }
}
