namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum MilestoneState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
