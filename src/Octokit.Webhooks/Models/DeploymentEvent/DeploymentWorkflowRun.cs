namespace Octokit.Webhooks.Models.DeploymentEvent;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record DeploymentWorkflowRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("head_branch")]
    public string HeadBranch { get; init; } = null!;

    [JsonPropertyName("head_sha")]
    public string HeadSha { get; init; } = null!;

    [JsonPropertyName("run_number")]
    public long RunNumber { get; init; }

    [JsonPropertyName("event")]
    public string Event { get; init; } = null!;

    [JsonPropertyName("status")]
    public DeploymentWorkflowRunStatus? Status { get; init; }

    [JsonPropertyName("conclusion")]
    public DeploymentWorkflowRunConclusion? Conclusion { get; init; }

    [JsonPropertyName("workflow_id")]
    public long WorkflowId { get; init; }

    [JsonPropertyName("check_suite_id")]
    public long CheckSuiteId { get; init; }

    [JsonPropertyName("check_suite_node_id")]
    public string CheckSuiteNodeId { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("pull_requests")]
    public IEnumerable<CheckRunPullRequest> PullRequests { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("actor")]
    public User Actor { get; init; } = null!;

    [JsonPropertyName("triggering_actor")]
    public User TriggeringActor { get; init; } = null!;

    [JsonPropertyName("run_attempt")]
    public long RunAttempt { get; init; }

    [JsonPropertyName("run_started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset RunStartedAt { get; init; }

    [JsonPropertyName("referenced_workflows")]
    public IEnumerable<ReferencedWorkflow> ReferencedWorkflows { get; init; } = null!;
}
