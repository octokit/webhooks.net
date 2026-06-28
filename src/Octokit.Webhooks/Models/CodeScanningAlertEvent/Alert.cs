namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record Alert
{
    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("instances")]
    public IReadOnlyList<AlertInstance>? Instances { get; init; }

    [JsonPropertyName("instances_url")]
    public string? InstancesUrl { get; init; }

    [JsonPropertyName("most_recent_instance")]
    public AlertInstance? AlertInstance { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<AlertState>))]
    public StringEnum<AlertState>? State { get; init; }

    [JsonPropertyName("dismissed_by")]
    public User? DismissedBy { get; init; }

    [JsonPropertyName("dismissal_approved_by")]
    public User? DismissalApprovedBy { get; init; }

    [JsonPropertyName("dismissed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? DismissedAt { get; init; }

    [JsonPropertyName("dismissed_reason")]
    [JsonConverter(typeof(StringEnumConverter<DismissedReason>))]
    public StringEnum<DismissedReason>? DismissedReason { get; init; }

    [JsonPropertyName("dismissed_comment")]
    public string? DismissedComment { get; init; }

    [JsonPropertyName("fixed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? FixedAt { get; init; }

    [JsonPropertyName("rule")]
    public AlertRule? Rule { get; init; }

    [JsonPropertyName("tool")]
    public required AlertTool Tool { get; init; }

    [JsonPropertyName("assignees")]
    public IReadOnlyList<User>? Assignees { get; init; }
}
