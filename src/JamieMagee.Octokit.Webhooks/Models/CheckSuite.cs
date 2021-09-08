namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class CheckSuite
    {
        /**
       * The id of the check suite that this check run is part of.
       */
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }

        [JsonPropertyName("head_branch")]
        public string? HeadBranch { get; set; }

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; set; } = null!;

        [JsonPropertyName("status")]
        public CheckRunStatus Status { get; set; }

        [JsonPropertyName("conclusion")]
        public CheckRunConclusion? Conclusion { get; set; }

        [JsonPropertyName("pull_requests")]
        public IEnumerable<CheckRunPullRequest> PullRequests { get; set; } = null!;

        [JsonPropertyName("deployment")]
        public CheckRunDeployment? Deployment { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("before")]
        public string? Before { get; set; }

        [JsonPropertyName("after")]
        public string? After { get; set; }

        [JsonPropertyName("app")]
        public App App { get; set; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
