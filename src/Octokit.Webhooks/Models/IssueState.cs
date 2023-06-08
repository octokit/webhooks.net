namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum IssueState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
