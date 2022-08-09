namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum RefType
{
    Unknown = -1,
    [EnumMember(Value = "tag")]
    Tag,
    [EnumMember(Value = "branch")]
    Branch,
}
