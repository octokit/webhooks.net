namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public enum WorkflowJobStepStatus
{
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
