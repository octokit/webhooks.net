namespace JamieMagee.Octokit.Webhooks.Models.CheckRunEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public sealed record CheckRun
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("details_url")]
        public string DetailsUrl { get; set; }

        [JsonPropertyName("status")]
        public CheckRunStatus Status { get; set; }

        [JsonPropertyName("conclusion")]
        public CheckRunConclusion? Conclusion { get; set; }

        [JsonPropertyName("started_at")]
        public string StartedAt { get; set; } = null!;

        [JsonPropertyName("completed_at")]
        public string CompletedAt { get; set; }

        [JsonPropertyName("output")]
        public CheckRunOutput Output { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("check_suite")]
        public CheckSuite CheckSuite { get; set; } = null!;

        [JsonPropertyName("app")]
        public App App { get; set; } = null!;

        [JsonPropertyName("pull_requests")]
        public IEnumerable<CheckRunPullRequest> PullRequests { get; set; } = null!;
    }
}
