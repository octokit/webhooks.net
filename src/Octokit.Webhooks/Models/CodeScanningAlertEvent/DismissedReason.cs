namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public enum DismissedReason
{
    [EnumMember(Value = "false positive")]
    FalsePositive,
    [EnumMember(Value = "won't fix")]
    WontFix,
    [EnumMember(Value = "used in tests")]
    UsedInTests,
}
