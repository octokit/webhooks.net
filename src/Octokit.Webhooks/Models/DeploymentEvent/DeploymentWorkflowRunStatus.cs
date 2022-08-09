namespace Octokit.Webhooks.Models.DeploymentEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DeploymentWorkflowRunStatus
{
    Unknown = -1,
    [EnumMember(Value = "requested")]
    Requested,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "waiting")]
    Waiting,
}
