namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlertSecurityAdvisory
{
    [JsonPropertyName("ghsa_id")]
    public required string GhsaId { get; init; }

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("summary")]
    public required string Summary { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("vulnerabilities")]
    public required IReadOnlyList<DependabotAlertVulnerability> Vulnerabilities { get; init; }

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertSeverity>))]
    public required StringEnum<DependabotAlertSeverity> Severity { get; init; }

    [JsonPropertyName("cvss")]
    public required DependabotAlertCvss Cvss { get; init; }

    [JsonPropertyName("cwes")]
    public required IReadOnlyList<DependabotAlertCwe> Cwes { get; init; }

    [JsonPropertyName("identifiers")]
    public required IReadOnlyList<DependabotAlertIdentifier> Identifiers { get; init; }

    [JsonPropertyName("references")]
    public required IReadOnlyList<DependabotAlertReference> References { get; init; }

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
