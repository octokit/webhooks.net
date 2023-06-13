namespace Octokit.Webhooks.Models.CheckSuiteEvent;

[PublicAPI]
public enum CheckSuiteConclusion
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
    [EnumMember(Value = "skipped")]
    Skipped,
    [EnumMember(Value = "startup_failure")]
    StartupFailure,
}
