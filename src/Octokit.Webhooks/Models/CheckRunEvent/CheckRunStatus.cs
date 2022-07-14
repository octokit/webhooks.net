namespace Octokit.Webhooks.Models.CheckRunEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum CheckRunStatus
{
    Unknown = -1,
    [EnumMember(Value = "requested")]
    Requested,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "waiting")]
    Waiting,
}
