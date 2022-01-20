namespace Octokit.Webhooks.Models.WorkflowJobEvent
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record WorkflowJob
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("run_id")]
        public int RunId { get; init; }

        [JsonPropertyName("run_attempt")]
        public int RunAttempt { get; init; }

        [JsonPropertyName("run_url")]
        public string RunUrl { get; init; } = null!;

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; init; } = null!;

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("check_run_url")]
        public string CheckRunUrl { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("status")]
        public WorkflowJobStatus Status { get; init; }

        [JsonPropertyName("steps")]
        public IEnumerable<WorkflowJobStep> Steps { get; init; } = null!;

        [JsonPropertyName("conclusion")]
        public WorkflowJobConclusion? Conclusion { get; init; }

        [JsonPropertyName("labels")]
        public IEnumerable<string> Labels { get; init; } = null!;

        [JsonPropertyName("runner_id")]
        public int? RunnerId { get; init; }

        [JsonPropertyName("runner_name")]
        public string? RunnerName { get; init; }

        [JsonPropertyName("runner_group_id")]
        public int? RunnerGroupId { get; init; }

        [JsonPropertyName("runner_group_name")]
        public string? RunnerGroupName { get; init; }

        [JsonPropertyName("started_at")]
        public string StartedAt { get; init; } = null!;

        [JsonPropertyName("completed_at")]
        public string? CompletedAt { get; init; }
    }
}
