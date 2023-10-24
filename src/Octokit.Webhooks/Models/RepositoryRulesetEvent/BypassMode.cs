namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum BypassMode
{
    [EnumMember(Value = "always")]
    Always,
    [EnumMember(Value = "pull_request")]
    PullRequest,
}
