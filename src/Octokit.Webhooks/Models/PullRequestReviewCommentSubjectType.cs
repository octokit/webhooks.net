namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum PullRequestReviewCommentSubjectType
{
    Unknown = -1,
    [EnumMember(Value = "line")]
    Line,
    [EnumMember(Value = "file")]
    File,
}
