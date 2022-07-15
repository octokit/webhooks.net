namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlert
{
    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertState>))]
    public StringEnum<DependabotAlertState> State { get; init; } = null!;

    [JsonPropertyName("dependency")]
    public DependabotAlertDependency Dependency { get; init; } = null!;

    [JsonPropertyName("security_advisory")]
    public DependabotAlertSecurityAdvisory SecurityAdvisory { get; init; } = null!;

    [JsonPropertyName("security_vulnerability")]
    public DependabotAlertVulnerability SecurityVulnerability { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("dismissed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? DismissedAt { get; init; }

    [JsonPropertyName("dismissed_by")]
    public User? DismissedBy { get; init; }

    [JsonPropertyName("dismissed_reason")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertDismissedReason>))]
    public StringEnum<DependabotAlertDismissedReason>? DismissedReason { get; init; }

    [JsonPropertyName("dismissed_comment")]
    public string? DismissedComment { get; init; }

    [JsonPropertyName("fixed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? FixedAt { get; init; }
}
