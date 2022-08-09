namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum CheckSuiteStatus
{
    Unknown = -1,
    [EnumMember(Value = "queued")]
    Queued,
    [EnumMember(Value = "in_progress")]
    InProgress,
    [EnumMember(Value = "completed")]
    Completed,
}
