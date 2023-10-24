namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public enum ActorType
{
    [EnumMember(Value = "RepositoryRole")]
    RepositoryRole,
    [EnumMember(Value = "Team")]
    Team,
    [EnumMember(Value = "Integration")]
    Integration,
    [EnumMember(Value = "OrganizationAdmin")]
    OrganizationAdmin,
}
