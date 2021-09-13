namespace JamieMagee.Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AlertInstance
    {
        [JsonPropertyName("ref")]
        public string Ref { get; init; }

        [JsonPropertyName("analysis_key")]
        public string analysis_key { get; init; }

        [JsonPropertyName("environment")]
        public string environment { get; init; }

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
