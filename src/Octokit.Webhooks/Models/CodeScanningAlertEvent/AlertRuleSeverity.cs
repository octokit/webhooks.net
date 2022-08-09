namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum AlertRuleSeverity
{
    Unknown = -1,
    [EnumMember(Value = "none")]
    Open,
    [EnumMember(Value = "note")]
    Note,
    [EnumMember(Value = "warning")]
    Warning,
    [EnumMember(Value = "error")]
    Error,
}
