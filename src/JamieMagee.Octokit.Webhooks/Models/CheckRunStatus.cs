namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CheckRunStatus
    {
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "queued")]
        Queued,
    }
}
