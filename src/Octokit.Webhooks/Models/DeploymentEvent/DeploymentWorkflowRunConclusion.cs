namespace Octokit.Webhooks.Models.DeploymentEvent;

[PublicAPI]
public enum DeploymentWorkflowRunConclusion
{
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "neutral")]
    Neutral,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "timed_out")]
    TimedOut,
    [EnumMember(Value = "action_required")]
    ActionRequired,
    [EnumMember(Value = "stale")]
    Stale,
}
