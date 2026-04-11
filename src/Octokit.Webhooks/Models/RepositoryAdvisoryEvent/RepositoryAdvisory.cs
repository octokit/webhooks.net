namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisory
{
    [JsonPropertyName("ghsa_id")]
    public required string GhsaId { get; init; }

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("summary")]
    public required string Summary { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisorySeverity>))]
    public StringEnum<RepositoryAdvisorySeverity>? Severity { get; init; }

    [JsonPropertyName("author")]
    public User? Author { get; init; }

    [JsonPropertyName("publisher")]
    public User? Publisher { get; init; }

    [JsonPropertyName("identifiers")]
    public required IReadOnlyList<RepositoryAdvisoryIdentifier> Identifiers { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryState>))]
    public required StringEnum<RepositoryAdvisoryState> State { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }

    [JsonPropertyName("published_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? PublishedAt { get; init; }

    [JsonPropertyName("closed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ClosedAt { get; init; }

    [JsonPropertyName("withdrawn_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? WithdrawnAt { get; init; }

    [JsonPropertyName("submission")]
    public RepositoryAdvisorySubmission? Submission { get; init; }

    [JsonPropertyName("vulnerabilities")]
    public IReadOnlyList<RepositoryAdvisoryVulnerability>? Vulnerabilities { get; init; }

    [JsonPropertyName("cvss")]
    public RepositoryAdvisoryCvss? Cvss { get; init; }

    [JsonPropertyName("cvss_severities")]
    public RepositoryAdvisoryCvssSeverities? CvssSeverities { get; init; }

    [JsonPropertyName("cwes")]
    public IReadOnlyList<RepositoryAdvisoryCwe>? Cwes { get; init; }

    [JsonPropertyName("cwe_ids")]
    public IReadOnlyList<string>? CweIds { get; init; }

    [JsonPropertyName("credits")]
    public IReadOnlyList<RepositoryAdvisoryCredit>? Credits { get; init; }

    [JsonPropertyName("credits_detailed")]
    public IReadOnlyList<RepositoryAdvisoryCreditDetailed>? CreditsDetailed { get; init; }

    [JsonPropertyName("collaborating_users")]
    public IReadOnlyList<User>? CollaboratingUsers { get; init; }

    [JsonPropertyName("collaborating_teams")]
    public IReadOnlyList<Team>? CollaboratingTeams { get; init; }

    [JsonPropertyName("private_fork")]
    public Repository? PrivateFork { get; init; }
}
