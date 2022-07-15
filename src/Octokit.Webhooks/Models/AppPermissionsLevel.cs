namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum AppPermissionsLevel
{
    [EnumMember(Value = "read")]
    Read,
    [EnumMember(Value = "write")]
    Write,
}
