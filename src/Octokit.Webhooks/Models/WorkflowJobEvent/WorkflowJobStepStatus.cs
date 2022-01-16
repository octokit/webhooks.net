namespace Octokit.Webhooks.Models.WorkflowJobEvent
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum WorkflowJobStepStatus
    {
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
    }
}
