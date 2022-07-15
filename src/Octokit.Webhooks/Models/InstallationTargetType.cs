namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum InstallationTargetType
{
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
