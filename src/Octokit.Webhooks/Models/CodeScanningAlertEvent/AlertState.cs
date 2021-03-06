namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

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
