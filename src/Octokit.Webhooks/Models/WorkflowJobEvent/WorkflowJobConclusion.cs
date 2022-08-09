namespace Octokit.Webhooks.Models.WorkflowJobEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum WorkflowJobConclusion
{
    Unknown = -1,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "failure")]
    Failure,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "skipped")]
    Skipped,
}
