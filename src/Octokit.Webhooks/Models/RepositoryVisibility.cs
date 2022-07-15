namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum RepositoryVisibility
{
    [EnumMember(Value = "public")]
    Public,
    [EnumMember(Value = "private")]
    Private,
    [EnumMember(Value = "internal")]
    Internal,
}
