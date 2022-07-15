namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public enum StatusState
{
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "error")]
    Error,
}
