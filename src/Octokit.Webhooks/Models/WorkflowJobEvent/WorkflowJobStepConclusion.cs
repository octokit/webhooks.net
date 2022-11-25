namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobStepConclusion
{
    Unknown = -1,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "skipped")]
    Skipped,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "queued")]
    Queued,
}
