namespace Octokit.Webhooks.Models.CheckSuiteEvent;

using Octokit.Webhooks.Models.CheckRunEvent;

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
    public required string HeadSha { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<CheckSuiteStatus>))]
    public StringEnum<CheckSuiteStatus>? Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<CheckSuiteConclusion>))]
    public StringEnum<CheckSuiteConclusion>? Conclusion { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("before")]
    public string? Before { get; init; }

    [JsonPropertyName("after")]
    public required string After { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<CheckRunPullRequest> PullRequests { get; init; }

    [JsonPropertyName("app")]
    public required App App { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("rerequestable")]
    public bool Rerequestable { get; init; }

    [JsonPropertyName("runs_rerequestable")]
    public bool RunsRerequestable { get; init; }

    [JsonPropertyName("latest_check_runs_count")]
    public long LatestCheckRunsCount { get; init; }

    [JsonPropertyName("check_runs_url")]
    public required string CheckRunsUrl { get; init; }

    [JsonPropertyName("head_commit")]
    public required SimpleCommit HeadCommit { get; init; }
}
