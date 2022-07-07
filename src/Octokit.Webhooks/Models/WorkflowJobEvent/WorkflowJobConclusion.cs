namespace Octokit.Webhooks.Models.WorkflowJobEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum WorkflowJobConclusion
{
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "skipped")]
    Skipped,
}
