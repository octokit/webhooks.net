namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
public enum WorkflowJobStatus
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
