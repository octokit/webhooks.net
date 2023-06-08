namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public enum DependabotAlertState
{
    [EnumMember(Value = "dismissed")]
    Dismissed,
    [EnumMember(Value = "fixed")]
    Fixed,
    [EnumMember(Value = "open")]
    Open,
}
