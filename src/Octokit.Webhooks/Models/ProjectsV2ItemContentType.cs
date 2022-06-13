namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ProjectsV2ItemContentType
{
    [EnumMember(Value = "DraftIssue")]
    DraftIssue,
    [EnumMember(Value = "Issue")]
    Issue,
    [EnumMember(Value = "PullRequest")]
    PullRequest,
}