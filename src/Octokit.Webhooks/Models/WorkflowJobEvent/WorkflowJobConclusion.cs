namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public enum WorkflowJobConclusion
{
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "skipped")]
    Skipped,
}
