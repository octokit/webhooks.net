namespace Octokit.Webhooks.Models.CheckRunEvent;

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
    public required StringEnum<CheckSuiteStatus> Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<CheckSuiteConclusion>))]
    public StringEnum<CheckSuiteConclusion>? Conclusion { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("before")]
    public string? Before { get; init; }

    [JsonPropertyName("after")]
    public string? After { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<CheckRunPullRequest> PullRequests { get; init; }

    [JsonPropertyName("deployment")]
    public Deployment? Deployment { get; init; }

    [JsonPropertyName("app")]
    public required App App { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
