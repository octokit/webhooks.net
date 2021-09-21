namespace Octokit.Webhooks.Models.CheckSuiteEvent
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CheckSuiteStatus
    {
        [EnumMember(Value = "requested")]
        Requested,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "queued")]
        Queued,
    }
}
