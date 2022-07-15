namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
public enum DependabotAlertSeverity
{
    [EnumMember(Value = "low")]
    Low,
    [EnumMember(Value = "medium")]
    Medium,
    [EnumMember(Value = "high")]
    High,
    [EnumMember(Value = "critical")]
    Critical,
}
