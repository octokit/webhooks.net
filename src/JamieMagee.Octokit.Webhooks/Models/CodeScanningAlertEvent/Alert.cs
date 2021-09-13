namespace JamieMagee.Octokit.Webhooks.Models.CodeScanningAlertEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Alert
    {
        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; }

        [JsonPropertyName("instances")]
        public IEnumerable<AlertInstance> Instances { get; init; } = null!;

        [JsonPropertyName("most_recent_instance")]
        public AlertInstance AlertInstance { get; init; } = null!;

        [JsonPropertyName("state")]
        public AlertState State { get; init; }

        [JsonPropertyName("dismissed_by")]
        public User? DismissedBy { get; init; }

        [JsonPropertyName("dismissed_at")]
        public string? DismissedAt { get; init; }

        [JsonPropertyName("dismissed_reason")]
        public DismissedReason? DismissedReason { get; init; }

        [JsonPropertyName("rule")]
        public AlertRule? Rule { get; init; }

        [JsonPropertyName("tool")]
        public AlertTool Tool { get; init; }
    }
}
