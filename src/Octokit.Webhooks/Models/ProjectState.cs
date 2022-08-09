namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ProjectState
{
    Unknown = -1,
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
