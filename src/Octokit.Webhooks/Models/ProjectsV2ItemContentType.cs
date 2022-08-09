namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ProjectsV2ItemContentType
{
    Unknown = -1,
    [EnumMember(Value = "DraftIssue")]
    DraftIssue,
    [EnumMember(Value = "Issue")]
    Issue,
    [EnumMember(Value = "PullRequest")]
    PullRequest,
}
