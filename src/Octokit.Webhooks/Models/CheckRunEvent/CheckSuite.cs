namespace Octokit.Webhooks.Models.CheckRunEvent
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record CheckSuite
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; init; }

        [JsonPropertyName("head_branch")]
        public string? HeadBranch { get; init; }

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; init; } = null!;

        [JsonPropertyName("status")]
        public CheckSuiteStatus Status { get; init; }

        [JsonPropertyName("conclusion")]
        public CheckSuiteConclusion? Conclusion { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("before")]
        public string? Before { get; init; }

        [JsonPropertyName("after")]
        public string? After { get; init; }

        [JsonPropertyName("pull_requests")]
        public IEnumerable<CheckRunPullRequest> PullRequests { get; init; } = null!;

        [JsonPropertyName("deployment")]
        public Deployment? Deployment { get; init; }

        [JsonPropertyName("app")]
        public App App { get; init; } = null!;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
