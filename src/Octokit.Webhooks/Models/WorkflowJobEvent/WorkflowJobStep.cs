namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public sealed record WorkflowJobStep
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobStepStatus>))]
    public required StringEnum<WorkflowJobStepStatus> Status { get; init; }

    [JsonPropertyName("conclusion")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowJobStepConclusion>))]
    public StringEnum<WorkflowJobStepConclusion>? Conclusion { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("started_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? StartedAt { get; init; }

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }
}
