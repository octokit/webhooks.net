namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisory
{
    [JsonPropertyName("cvss")]
    public required SecurityAdvisoryCvss Cvss { get; init; }

    [JsonPropertyName("cwes")]
    public required IReadOnlyList<SecurityAdvisoryCwe> Cwes { get; init; }

    [JsonPropertyName("ghsa_id")]
    public required string GhsaId { get; init; }

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("summary")]
    public required string Summary { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("severity")]
    public required string Severity { get; init; }

    [JsonPropertyName("identifiers")]
    public required IReadOnlyList<SecurityAdvisoryIdentifier> Identifiers { get; init; }

    [JsonPropertyName("references")]
    public required IReadOnlyList<SecurityAdvisoryReference> References { get; init; }

    [JsonPropertyName("published_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset PublishedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("withdrawn_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? WithdrawnAt { get; init; }

    [JsonPropertyName("vulnerabilities")]
    public required IReadOnlyList<SecurityAdvisoryVulnerability> Vulnerabilities { get; init; }
}
