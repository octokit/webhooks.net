namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowRun
{
    [JsonPropertyName("artifacts_url")]
    public required string ArtifactsUrl { get; init; }

    [JsonPropertyName("cancel_url")]
    public required string CancelUrl { get; init; }

    [JsonPropertyName("check_suite_url")]
    public required string CheckSuiteUrl { get; init; }

    [JsonPropertyName("check_suite_id")]
    public long CheckSuiteId { get; init; }

    [JsonPropertyName("check_suite_node_id")]
    public required string CheckSuiteNodeId { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowRunConclusion>))]
    public StringEnum<WorkflowRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("display_title")]
    public required string DisplayTitle { get; init; }

    [JsonPropertyName("event")]
    public required string Event { get; init; }

    [JsonPropertyName("head_branch")]
    public required string HeadBranch { get; init; }

    [JsonPropertyName("head_commit")]
    public required SimpleCommit HeadCommit { get; init; }

    [JsonPropertyName("head_repository")]
    public required RepositoryLite HeadRepository { get; init; }

    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("jobs_url")]
    public required string JobsUrl { get; init; }

    [JsonPropertyName("logs_url")]
    public required string LogsUrl { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<WorkflowPullRequest> PullRequests { get; init; }

    [JsonPropertyName("repository")]
    public required RepositoryLite Repository { get; init; }

    [JsonPropertyName("rerun_url")]
    public required string RerunUrl { get; init; }

    [JsonPropertyName("run_number")]
    public long RunNumber { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowRunStatus>))]
    public required StringEnum<WorkflowRunStatus> Status { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("workflow_id")]
    public long WorkflowId { get; init; }

    [JsonPropertyName("workflow_url")]
    public required string WorkflowUrl { get; init; }

    [JsonPropertyName("run_attempt")]
    public long RunAttempt { get; init; }

    [JsonPropertyName("run_started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset RunStartedAt { get; init; }

    [JsonPropertyName("previous_attempt_url")]
    public string? PreviousAttemptUrl { get; init; }

    [JsonPropertyName("actor")]
    public required User Actor { get; init; }

    [JsonPropertyName("triggering_actor")]
    public required User TriggeringActor { get; init; }

    [JsonPropertyName("referenced_workflows")]
    public IReadOnlyList<ReferencedWorkflow>? ReferencedWorkflows { get; init; }
}
