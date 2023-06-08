namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public enum AlertState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "dismissed")]
    Dismissed,
    [EnumMember(Value = "fixed")]
    Fixed,
}
