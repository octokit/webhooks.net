namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum ProjectsV2ItemContentType
{
    [EnumMember(Value = "DraftIssue")]
    DraftIssue,
    [EnumMember(Value = "Issue")]
    Issue,
    [EnumMember(Value = "PullRequest")]
    PullRequest,
}
