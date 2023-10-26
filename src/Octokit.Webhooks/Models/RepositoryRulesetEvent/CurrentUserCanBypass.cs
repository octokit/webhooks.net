namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum CurrentUserCanBypass
{
    [EnumMember(Value = "always")]
    Always,
    [EnumMember(Value = "pull_requests_only")]
    PullRequestsOnly,
    [EnumMember(Value = "never")]
    Never,
}
