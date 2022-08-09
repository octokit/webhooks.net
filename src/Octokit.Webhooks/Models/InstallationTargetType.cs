namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum InstallationTargetType
{
    Unknown = -1,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
