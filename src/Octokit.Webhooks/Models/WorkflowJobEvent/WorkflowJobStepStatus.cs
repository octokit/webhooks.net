namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobStepStatus
{
    Unknown = -1,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
