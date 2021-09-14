namespace JamieMagee.Octokit.Webhooks.Models.CheckSuiteEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models.CheckRunEvent;

    public sealed record CheckSuite
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; init; }

        [JsonPropertyName("head_branch")]
        public string? HeadBranch { get; init; }

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; init; } = null!;

        [JsonPropertyName("status")]
        public CheckSuiteStatus? Status { get; init; }

        [JsonPropertyName("conclusion")]
        public CheckSuiteConclusion? Conclusion { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("before")]
        public string? Before { get; init; }

        [JsonPropertyName("after")]
        public string After { get; init; } = null!;

        [JsonPropertyName("pull_requests")]
        public IEnumerable<CheckRunPullRequest> PullRequests { get; init; } = null!;

        [JsonPropertyName("app")]
        public App App { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("latest_check_runs_count")]
        public int LatestCheckRunsCount { get; init; }

        [JsonPropertyName("check_runs_url")]
        public string CheckRunsUrl { get; init; } = null!;

        [JsonPropertyName("head_commit")]
        public SimpleCommit HeadCommit { get; init; } = null!;
    }
}
