namespace Octokit.Webhooks.Models.DeploymentStatusEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DeploymentStatusState
{
    Unknown = -1,
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "error")]
    Error,
    [EnumMember(Value = "waiting")]
    Waiting,
    [EnumMember(Value = "queued")]
    Queued,
}
