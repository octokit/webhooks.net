namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum WorkflowJobRunStatus
{
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
    [EnumMember(Value = "waiting")]
    Waiting,
}
