namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ActiveLockReason
{
    [EnumMember(Value = "resolved")]
    Resolved,
    [EnumMember(Value = "off-topic")]
    OffTopic,
    [EnumMember(Value = "too heated")]
    TooHeated,
    [EnumMember(Value = "spam")]
    Spam,
}