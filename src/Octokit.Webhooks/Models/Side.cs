namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum Side
{
    Unknown = -1,
    [EnumMember(Value = "LEFT")]
    Left,
    [EnumMember(Value = "RIGHT")]
    Right,
}
