namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum PatternOperator
{
    [EnumMember(Value = "starts_with")]
    StartsWith,
    [EnumMember(Value = "ends_with")]
    EndsWith,
    [EnumMember(Value = "contains")]
    Contains,
    [EnumMember(Value = "regex")]
    Regex,
}
