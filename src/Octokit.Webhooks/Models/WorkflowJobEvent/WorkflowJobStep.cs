namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public sealed record WorkflowJobStep
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("status")]
    public WorkflowJobStepStatus Status { get; init; }

    [JsonPropertyName("conclusion")]
    public WorkflowJobStepConclusion? Conclusion { get; init; }

    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("started_at")]
    public string StartedAt { get; init; } = null!;

    [JsonPropertyName("completed_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? CompletedAt { get; init; }
}
