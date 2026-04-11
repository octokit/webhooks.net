namespace Octokit.Webhooks.Models.DeploymentEvent;

using Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record DeploymentWorkflowRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("head_branch")]
    public required string HeadBranch { get; init; }

    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("run_number")]
    public long RunNumber { get; init; }

    [JsonPropertyName("event")]
    public required string Event { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<DeploymentWorkflowRunStatus>))]
    public StringEnum<DeploymentWorkflowRunStatus>? Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<DeploymentWorkflowRunConclusion>))]
    public StringEnum<DeploymentWorkflowRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("workflow_id")]
    public long WorkflowId { get; init; }

    [JsonPropertyName("check_suite_id")]
    public long CheckSuiteId { get; init; }

    [JsonPropertyName("check_suite_node_id")]
    public required string CheckSuiteNodeId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<CheckRunPullRequest> PullRequests { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("actor")]
    public required User Actor { get; init; }

    [JsonPropertyName("triggering_actor")]
    public required User TriggeringActor { get; init; }

    [JsonPropertyName("run_attempt")]
    public long RunAttempt { get; init; }

    [JsonPropertyName("run_started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset RunStartedAt { get; init; }

    [JsonPropertyName("referenced_workflows")]
    public IReadOnlyList<ReferencedWorkflow>? ReferencedWorkflows { get; init; }
}
