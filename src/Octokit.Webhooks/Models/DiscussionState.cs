namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum DiscussionState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "locked")]
    Locked,
    [EnumMember(Value = "converting")]
    Converting,
}
