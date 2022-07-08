namespace Octokit.Webhooks.Models.WorkflowJobEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobStepConclusion
{
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "skipped")]
    Skipped,
    [EnumMember(Value = "success")]
    Success,
}
