namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum UserType
{
    Unknown = -1,
    [EnumMember(Value = "Bot")]
    Bot,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
