namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum ReviewerType
{
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Team")]
    Team,
}
