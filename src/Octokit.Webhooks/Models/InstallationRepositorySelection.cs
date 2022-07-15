namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum InstallationRepositorySelection
{
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "selected")]
    Selected,
}
