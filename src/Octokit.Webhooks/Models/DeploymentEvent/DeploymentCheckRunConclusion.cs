namespace Octokit.Webhooks.Models.DeploymentEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DeploymentCheckRunConclusion
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
    [EnumMember(Value = "actionRequired")]
    ActionRequired,
    [EnumMember(Value = "stale")]
    Stale,
    [EnumMember(Value = "skipped")]
    Skipped,
}
