namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum EnforcementLevel
{
    Unknown = -1,
    [EnumMember(Value = "off")]
    Off,
    [EnumMember(Value = "non_admins")]
    NonAdmins,
    [EnumMember(Value = "everyone")]
    Everyone,
}
