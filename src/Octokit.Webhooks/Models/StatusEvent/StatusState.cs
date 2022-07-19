namespace Octokit.Webhooks.Models.StatusEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum StatusState
{
    Unknown = -1,
    [EnumMember(Value = "pending")]
    Pending,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "error")]
    Error,
}
