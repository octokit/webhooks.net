namespace Octokit.Webhooks.Models.SecretScanningAlertEvent;

[PublicAPI]
public enum AlertResolution
{
    [EnumMember(Value = "false_positive")]
    FalsePositive,
    [EnumMember(Value = "wontfix")]
    Wontfix,
    [EnumMember(Value = "revoked")]
    Revoked,
    [EnumMember(Value = "used_in_tests")]
    UsedInTests,
}
