namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum RepositoryVisibility
{
    Unknown = -1,
    [EnumMember(Value = "public")]
    Public,
    [EnumMember(Value = "private")]
    Private,
    [EnumMember(Value = "internal")]
    Internal,
}
