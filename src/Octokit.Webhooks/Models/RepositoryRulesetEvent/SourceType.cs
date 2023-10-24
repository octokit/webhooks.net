namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum SourceType
{
    [EnumMember(Value = "Repository")]
    Repository,
    [EnumMember(Value = "Organization")]
    Organization,
}
