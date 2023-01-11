namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DependabotAlertDismissedReason
{
    Unknown = -1,
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
