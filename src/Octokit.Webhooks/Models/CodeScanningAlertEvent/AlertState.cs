namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum AlertState
{
    Unknown = -1,
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "dismissed")]
    Dismissed,
    [EnumMember(Value = "fixed")]
    Fixed,
}
