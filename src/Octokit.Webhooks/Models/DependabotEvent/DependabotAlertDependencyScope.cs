namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public enum DependabotAlertDependencyScope
{
    [EnumMember(Value = "development")]
    Development,
    [EnumMember(Value = "runtime")]
    Runtime,
}
