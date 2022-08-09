namespace Octokit.Webhooks.Models.CheckSuiteEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum CheckSuiteStatus
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
}
