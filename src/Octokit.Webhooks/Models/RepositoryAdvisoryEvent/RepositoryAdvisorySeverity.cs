namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public enum RepositoryAdvisorySeverity
{
    [EnumMember(Value = "critical")]
    Critical,
    [EnumMember(Value = "high")]
    High,
    [EnumMember(Value = "medium")]
    Medium,
    [EnumMember(Value = "low")]
    Low,
}
