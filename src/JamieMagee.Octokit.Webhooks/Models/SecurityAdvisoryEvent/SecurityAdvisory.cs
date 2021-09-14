namespace JamieMagee.Octokit.Webhooks.Models.SecurityAdvisoryEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public sealed record SecurityAdvisory
    {
        [JsonPropertyName("cvss")]
        public SecurityAdvisoryCvss Cvss { get; init; } = null!;

        [JsonPropertyName("cwes")]
        public IEnumerable<SecurityAdvisoryCwe> Cwes { get; init; } = null!;

        [JsonPropertyName("ghsa_id")]
        public string GhsaId { get; init; } = null!;

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
        public string PublishedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("withdrawn_at")]
        public string? WithdrawnAt { get; init; }

        [JsonPropertyName("vulnerabilities")]
        public IEnumerable<SecurityAdvisoryVulnerability> Vulnerabilities { get; init; } = null!;
    }
}
