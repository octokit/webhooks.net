namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public sealed record RepositoryAdvisory
{
    [JsonPropertyName("ghsa_id")]
    public string GhsaId { get; init; } = null!;

    [JsonPropertyName("cve_id")]
    public string? CveId { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("summary")]
    public string Summary { get; init; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = null!;

    [JsonPropertyName("severity")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisorySeverity>))]
    public StringEnum<RepositoryAdvisorySeverity>? Severity { get; init; }

    [JsonPropertyName("author")]
    public User? Author { get; init; }

    [JsonPropertyName("publisher")]
    public User? Publisher { get; init; }

    [JsonPropertyName("identifiers")]
    public IEnumerable<RepositoryAdvisoryIdentifier> Identifiers { get; init; } = null!;

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<RepositoryAdvisoryState>))]
    public StringEnum<RepositoryAdvisoryState> State { get; init; } = null!;

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
    public IEnumerable<RepositoryAdvisoryVulnerability>? Vulnerabilities { get; init; }

    [JsonPropertyName("cvss")]
    public RepositoryAdvisoryCvss? Cvss { get; init; }

    [JsonPropertyName("cvss_severities")]
    public RepositoryAdvisoryCvssSeverities? CvssSeverities { get; init; }

    [JsonPropertyName("cwes")]
    public IEnumerable<RepositoryAdvisoryCwe>? Cwes { get; init; }

    [JsonPropertyName("cwe_ids")]
    public IEnumerable<string>? CweIds { get; init; }

    [JsonPropertyName("credits")]
    public IEnumerable<RepositoryAdvisoryCredit>? Credits { get; init; }

    [JsonPropertyName("credits_detailed")]
    public IEnumerable<RepositoryAdvisoryCreditDetailed>? CreditsDetailed { get; init; }

    [JsonPropertyName("collaborating_users")]
    public IEnumerable<User>? CollaboratingUsers { get; init; }

    [JsonPropertyName("collaborating_teams")]
    public IEnumerable<Team>? CollaboratingTeams { get; init; }

    [JsonPropertyName("private_fork")]
    public Repository? PrivateFork { get; init; }
}
