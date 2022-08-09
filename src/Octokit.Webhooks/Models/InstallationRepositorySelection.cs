namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum InstallationRepositorySelection
{
    Unknown = -1,
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "selected")]
    Selected,
}
