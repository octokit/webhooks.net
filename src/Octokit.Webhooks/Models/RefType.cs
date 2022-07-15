namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum RefType
{
    [EnumMember(Value = "tag")]
    Tag,
    [EnumMember(Value = "branch")]
    Branch,
}
