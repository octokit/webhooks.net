namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum IssueState
{
    Unknown = -1,
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
