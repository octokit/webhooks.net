namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public enum AlertRuleSeverity
{
    [EnumMember(Value = "none")]
    None,
    [EnumMember(Value = "note")]
    Note,
    [EnumMember(Value = "warning")]
    Warning,
    [EnumMember(Value = "error")]
    Error,
}
