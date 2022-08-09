namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobStatus
{
    Unknown = -1,
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
