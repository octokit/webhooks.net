namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

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
