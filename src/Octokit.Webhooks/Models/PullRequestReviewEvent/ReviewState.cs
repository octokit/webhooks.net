namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ReviewState
{
    Unknown = -1,
    [EnumMember(Value = "commented")]
    Commented,
    [EnumMember(Value = "changes_requested")]
    ChangesRequested,
    [EnumMember(Value = "approved")]
    Approved,
    [EnumMember(Value = "dismissed")]
    Dismissed,
}
