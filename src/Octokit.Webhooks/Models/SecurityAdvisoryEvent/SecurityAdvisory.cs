namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

[PublicAPI]
public sealed record SecurityAdvisory
{
    [JsonPropertyName("cvss")]
    public SecurityAdvisoryCvss Cvss { get; init; } = null!;

    [JsonPropertyName("cwes")]
    public IEnumerable<SecurityAdvisoryCwe> Cwes { get; init; } = null!;

    [JsonPropertyName("ghsa_id")]
    public string GhsaId { get; init; } = null!;

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("summary")]
    public string Summary { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("severity")]
    public string Severity { get; init; } = null!;

    [JsonPropertyName("identifiers")]
    public IEnumerable<SecurityAdvisoryIdentifier> Identifiers { get; init; } = null!;

    [JsonPropertyName("references")]
    public IEnumerable<SecurityAdvisoryReference> References { get; init; } = null!;

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
    public IEnumerable<SecurityAdvisoryVulnerability> Vulnerabilities { get; init; } = null!;
}
