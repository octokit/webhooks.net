namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public enum RepositoryAdvisoryCreditType
{
    [EnumMember(Value = "analyst")]
    Analyst,
    [EnumMember(Value = "finder")]
    Finder,
    [EnumMember(Value = "reporter")]
    Reporter,
    [EnumMember(Value = "coordinator")]
    Coordinator,
    [EnumMember(Value = "remediation_developer")]
    RemediationDeveloper,
    [EnumMember(Value = "remediation_reviewer")]
    RemediationReviewer,
    [EnumMember(Value = "remediation_verifier")]
    RemediationVerifier,
    [EnumMember(Value = "tool")]
    Tool,
    [EnumMember(Value = "sponsor")]
    Sponsor,
    [EnumMember(Value = "other")]
    Other,
}
