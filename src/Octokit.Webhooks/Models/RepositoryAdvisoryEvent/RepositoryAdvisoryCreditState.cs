namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public enum RepositoryAdvisoryCreditState
{
    [EnumMember(Value = "accepted")]
    Accepted,
    [EnumMember(Value = "declined")]
    Declined,
    [EnumMember(Value = "pending")]
    Pending,
}
