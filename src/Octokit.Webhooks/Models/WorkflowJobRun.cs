namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowJobRun
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobRunStatus>))]
    public StringEnum<WorkflowJobRunStatus> Status { get; init; } = null!;

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobRunConclusion>))]
    public StringEnum<WorkflowJobRunConclusion>? Conclusion { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("environment")]
    public string Environment { get; init; } = null!;
}
