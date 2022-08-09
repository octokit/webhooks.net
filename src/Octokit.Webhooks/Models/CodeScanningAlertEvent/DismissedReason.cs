namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DismissedReason
{
    Unknown = -1,
    [EnumMember(Value = "false positive")]
    FalsePositive,
    [EnumMember(Value = "won't fix")]
    WontFix,
    [EnumMember(Value = "used in tests")]
    UsedInTests,
}
