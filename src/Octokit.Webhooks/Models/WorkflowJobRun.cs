namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowJobRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobRunStatus>))]
    public required StringEnum<WorkflowJobRunStatus> Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobRunConclusion>))]
    public StringEnum<WorkflowJobRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("environment")]
    public required string Environment { get; init; }
}
