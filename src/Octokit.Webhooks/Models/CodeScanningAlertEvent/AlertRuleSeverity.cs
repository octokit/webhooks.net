namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum AlertRuleSeverity
{
    [EnumMember(Value = "none")]
    Open,
    [EnumMember(Value = "note")]
    Note,
    [EnumMember(Value = "warning")]
    Warning,
    [EnumMember(Value = "error")]
    Error,
}
