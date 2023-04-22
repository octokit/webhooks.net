namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum PackageType
{
    Unknown = -1,
    [EnumMember(Value = "npm")]
    Npm,
    [EnumMember(Value = "maven")]
    Maven,
    [EnumMember(Value = "rubygems")]
    RubyGems,
    [EnumMember(Value = "docker")]
    Docker,
    [EnumMember(Value = "nuget")]
    NuGet,
    [EnumMember(Value = "CONTAINER")]
    Container,
}
