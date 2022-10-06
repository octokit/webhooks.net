namespace Octokit.Webhooks.Models.DependabotEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum DependabotAlertDependencyScope
{
    Unknown = -1,
    [EnumMember(Value = "development")]
    Development,
    [EnumMember(Value = "runtime")]
    Runtime,
}
