namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowRunConclusion
{
    Unknown = -1,
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
}
