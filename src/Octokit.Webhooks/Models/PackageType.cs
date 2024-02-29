namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum PackageType
{
    [EnumMember(Value = "npm")]
    Npm,
    [EnumMember(Value = "maven")]
    Maven,
    [EnumMember(Value = "rubygems")]
    RubyGems,
    [EnumMember(Value = "docker")]
    Docker,
    [EnumMember(Value = "NUGET")]
    NuGet,
    [EnumMember(Value = "CONTAINER")]
    Container,
}
