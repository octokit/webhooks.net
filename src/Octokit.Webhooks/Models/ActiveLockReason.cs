namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ActiveLockReason
{
    Unknown = -1,
    [EnumMember(Value = "resolved")]
    Resolved,
    [EnumMember(Value = "off-topic")]
    OffTopic,
    [EnumMember(Value = "too heated")]
    TooHeated,
    [EnumMember(Value = "spam")]
    Spam,
}
