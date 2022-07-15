namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public enum WorkflowJobStepConclusion
{
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
