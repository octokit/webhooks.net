namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public enum CheckSuiteStatus
{
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
