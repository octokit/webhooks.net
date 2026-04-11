namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public sealed record WorkflowJob
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("run_id")]
    public long RunId { get; init; }

    [JsonPropertyName("run_attempt")]
    public long RunAttempt { get; init; }

    [JsonPropertyName("run_url")]
    public required string RunUrl { get; init; }

    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("check_run_url")]
    public required string CheckRunUrl { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobStatus>))]
    public required StringEnum<WorkflowJobStatus> Status { get; init; }

    [JsonPropertyName("steps")]
    public required IReadOnlyList<WorkflowJobStep> Steps { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobConclusion>))]
    public StringEnum<WorkflowJobConclusion>? Conclusion { get; init; }

    [JsonPropertyName("labels")]
    public required IReadOnlyList<string> Labels { get; init; }

    [JsonPropertyName("runner_id")]
    public int? RunnerId { get; init; }

    [JsonPropertyName("runner_name")]
    public string? RunnerName { get; init; }

    [JsonPropertyName("runner_group_id")]
    public int? RunnerGroupId { get; init; }

    [JsonPropertyName("runner_group_name")]
    public string? RunnerGroupName { get; init; }

    [JsonPropertyName("started_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }

    [JsonPropertyName("workflow_name")]
    public string? WorkflowName { get; init; }

    [JsonPropertyName("head_branch")]
    public string? HeadBranch { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }
}
