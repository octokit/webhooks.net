namespace Octokit.Webhooks.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
public sealed record WorkflowRun
{
    [JsonPropertyName("artifacts_url")]
    public string ArtifactsUrl { get; init; } = null!;

    [JsonPropertyName("cancel_url")]
    public string CancelUrl { get; init; } = null!;

    [JsonPropertyName("check_suite_url")]
    public string CheckSuiteUrl { get; init; } = null!;

    [JsonPropertyName("check_suite_id")]
    public long CheckSuiteId { get; init; }

    [JsonPropertyName("check_suite_node_id")]
    public string CheckSuiteNodeId { get; init; } = null!;

    [JsonPropertyName("conclusion")]
    public WorkflowRunConclusion? Conclusion { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("event")]
    public string Event { get; init; } = null!;

    [JsonPropertyName("head_branch")]
    public string HeadBranch { get; init; } = null!;

    [JsonPropertyName("head_commit")]
    public SimpleCommit HeadCommit { get; init; } = null!;

    [JsonPropertyName("head_repository")]
    public RepositoryLite HeadRepository { get; init; } = null!;

    [JsonPropertyName("head_sha")]
    public string HeadSha { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("jobs_url")]
    public string JobsUrl { get; init; } = null!;

    [JsonPropertyName("logs_url")]
    public string LogsUrl { get; init; } = null!;

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("pull_requests")]
    public IEnumerable<WorkflowPullRequest> PullRequests { get; init; } = null!;

    [JsonPropertyName("repository")]
    public RepositoryLite Repository { get; init; } = null!;

    [JsonPropertyName("rerun_url")]
    public string RerunUrl { get; init; } = null!;

    [JsonPropertyName("run_number")]
    public long RunNumber { get; init; }

    [JsonPropertyName("status")]
    public WorkflowRunStatus Status { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("workflow_id")]
    public long WorkflowId { get; init; }

    [JsonPropertyName("workflow_url")]
    public string WorkflowUrl { get; init; } = null!;

    [JsonPropertyName("run_attempt")]
    public long RunAttempt { get; init; }

    [JsonPropertyName("run_started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset RunStartedAt { get; init; }

    [JsonPropertyName("previous_attempt_url")]
    public string? PreviousAttemptUrl { get; init; }

    [JsonPropertyName("actor")]
    public User Actor { get; init; } = null!;

    [JsonPropertyName("triggering_actor")]
    public User TriggeringActor { get; init; } = null!;

    [JsonPropertyName("referenced_workflows")]
    public IEnumerable<ReferencedWorkflow> ReferencedWorkflows { get; init; } = null!;
}
