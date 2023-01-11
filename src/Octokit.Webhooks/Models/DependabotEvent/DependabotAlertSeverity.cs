namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DependabotAlertSeverity
{
    Unknown = -1,
    [EnumMember(Value = "low")]
    Low,
    [EnumMember(Value = "medium")]
    Medium,
    [EnumMember(Value = "high")]
    High,
    [EnumMember(Value = "critical")]
    Critical,
}
