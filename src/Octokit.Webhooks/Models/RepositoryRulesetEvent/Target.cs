namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum Target
{
    [EnumMember(Value = "branch")]
    Branch,
    [EnumMember(Value = "tag")]
    Tag,
}
