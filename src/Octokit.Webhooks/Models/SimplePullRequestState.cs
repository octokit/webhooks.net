namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum SimplePullRequestState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
