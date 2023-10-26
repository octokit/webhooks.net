namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum Enforcement
{
    [EnumMember(Value = "disabled")]
    Disabled,
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "evaluate")]
    Evaluate,
}
