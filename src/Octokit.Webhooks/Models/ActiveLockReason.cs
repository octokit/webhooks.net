namespace Octokit.Webhooks.Models;

[PublicAPI]
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
