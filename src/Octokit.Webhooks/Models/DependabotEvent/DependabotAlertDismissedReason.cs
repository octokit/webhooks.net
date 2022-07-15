namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public enum DependabotAlertDismissedReason
{
    [EnumMember(Value = "fix_started")]
    FixStarted,
    [EnumMember(Value = "inaccurate")]
    Inaccurate,
    [EnumMember(Value = "no_bandwidth")]
    NoBandwidth,
    [EnumMember(Value = "not_used")]
    NotUsed,
    [EnumMember(Value = "tolerable_risk")]
    TolerableRisk,
}
