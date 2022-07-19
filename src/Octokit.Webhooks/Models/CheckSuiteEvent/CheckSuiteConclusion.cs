namespace Octokit.Webhooks.Models.CheckSuiteEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum CheckSuiteConclusion
{
    Unknown = -1,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "neutral")]
    Neutral,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "timed_out")]
    TimedOut,
    [EnumMember(Value = "actionRequired")]
    ActionRequired,
    [EnumMember(Value = "stale")]
    Stale,
}
