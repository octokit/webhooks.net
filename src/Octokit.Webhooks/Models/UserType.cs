namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum UserType
{
    [EnumMember(Value = "Bot")]
    Bot,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
