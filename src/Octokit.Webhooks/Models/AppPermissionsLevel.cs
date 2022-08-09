namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum AppPermissionsLevel
{
    Unknown = -1,
    [EnumMember(Value = "read")]
    Read,
    [EnumMember(Value = "write")]
    Write,
}
