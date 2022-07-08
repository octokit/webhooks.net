namespace Octokit.Webhooks.Models.WorkflowJobEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobStepStatus
{
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
