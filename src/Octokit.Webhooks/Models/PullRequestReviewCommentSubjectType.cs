namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum PullRequestReviewCommentSubjectType
{
    [EnumMember(Value = "line")]
    Line,
    [EnumMember(Value = "file")]
    File,
}
