namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum TeamParentPrivacy
{
    Unknown = -1,
    [EnumMember(Value = "Open")]
    Open,
    [EnumMember(Value = "Closed")]
    Closed,
    [EnumMember(Value = "Secret")]
    Secret,
}
