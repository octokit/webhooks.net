namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertSecurityAdvisory
{
    [JsonPropertyName("ghsa_id")]
    public string GhsaId { get; init; } = null!;

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("summary")]
    public string Summary { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("vulnerabilities")]
    public IEnumerable<DependabotAlertVulnerability> Vulnerabilities { get; init; } = null!;

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertSeverity>))]
    public StringEnum<DependabotAlertSeverity> Severity { get; init; } = null!;

    [JsonPropertyName("cvss")]
    public DependabotAlertCvss Cvss { get; init; } = null!;

    [JsonPropertyName("cwes")]
    public IEnumerable<DependabotAlertCwe> Cwes { get; init; } = null!;

    [JsonPropertyName("identifiers")]
    public IEnumerable<DependabotAlertIdentifier> Identifiers { get; init; } = null!;

    [JsonPropertyName("references")]
    public IEnumerable<DependabotAlertReference> References { get; init; } = null!;

    [JsonPropertyName("published_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset PublishedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("withdrawn_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? WithdrawnAt { get; init; }
}
