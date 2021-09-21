namespace Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record AlertInstance
    {
        [JsonPropertyName("ref")]
        public string Ref { get; init; } = null!;

        [JsonPropertyName("analysis_key")]
        public string AnalysisKey { get; init; } = null!;

        [JsonPropertyName("environment")]
        public string Environment { get; init; } = null!;

        [JsonPropertyName("state")]
        public AlertState State { get; init; }

        [JsonPropertyName("commit_sha")]
        public string? CommitSha { get; init; }

        [JsonPropertyName("message")]
        public AlertInstanceMessage? Message { get; init; }

        [JsonPropertyName("location")]
        public AlertInstanceLocation? Location { get; init; }

        [JsonPropertyName("classifications")]
        public IEnumerable<string>? Classifications { get; init; }
    }
}
