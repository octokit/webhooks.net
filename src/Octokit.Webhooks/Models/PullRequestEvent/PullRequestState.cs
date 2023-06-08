namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public enum PullRequestState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
