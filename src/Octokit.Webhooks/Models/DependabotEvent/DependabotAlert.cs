namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public sealed record DependabotAlert
{
    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<DependabotAlertState>))]
    public required StringEnum<DependabotAlertState> State { get; init; }

    [JsonPropertyName("dependency")]
    public required DependabotAlertDependency Dependency { get; init; }

    [JsonPropertyName("security_advisory")]
    public required DependabotAlertSecurityAdvisory SecurityAdvisory { get; init; }

    [JsonPropertyName("security_vulnerability")]
    public required DependabotAlertVulnerability SecurityVulnerability { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

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
