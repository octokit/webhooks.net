namespace Octokit.Webhooks.Models.SecretScanningAlertEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
