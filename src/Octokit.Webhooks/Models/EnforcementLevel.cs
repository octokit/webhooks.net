namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum EnforcementLevel
{
    [EnumMember(Value = "off")]
    Off,
    [EnumMember(Value = "non_admins")]
    NonAdmins,
    [EnumMember(Value = "everyone")]
    Everyone,
}
