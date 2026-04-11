namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record CheckRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; init; }

    [JsonPropertyName("head_sha")]
    public required string HeadSha { get; init; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("details_url")]
    public string? DetailsUrl { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<CheckRunStatus>))]
    public required StringEnum<CheckRunStatus> Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<CheckRunConclusion>))]
    public StringEnum<CheckRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("started_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }

    [JsonPropertyName("output")]
    public required CheckRunOutput Output { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("check_suite")]
    public required CheckSuite CheckSuite { get; init; }

    [JsonPropertyName("app")]
    public required App App { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<CheckRunPullRequest> PullRequests { get; init; }

    [JsonPropertyName("deployment")]
    public Deployment? Deployment { get; init; }
}
