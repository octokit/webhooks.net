namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public enum ReviewState
{
    [EnumMember(Value = "commented")]
    Commented,
    [EnumMember(Value = "changes_requested")]
    ChangesRequested,
    [EnumMember(Value = "approved")]
    Approved,
    [EnumMember(Value = "dismissed")]
    Dismissed,
}
