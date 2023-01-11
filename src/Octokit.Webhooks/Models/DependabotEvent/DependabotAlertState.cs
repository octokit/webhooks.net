namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DependabotAlertState
{
    Unknown = -1,
    [EnumMember(Value = "dismissed")]
    Dismissed,
    [EnumMember(Value = "fixed")]
    Fixed,
    [EnumMember(Value = "open")]
    Open,
}
