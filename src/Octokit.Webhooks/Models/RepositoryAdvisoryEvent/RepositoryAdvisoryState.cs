namespace Octokit.Webhooks.Models.RepositoryAdvisoryEvent;

[PublicAPI]
public enum RepositoryAdvisoryState
{
    [EnumMember(Value = "published")]
    Published,
    [EnumMember(Value = "closed")]
    Closed,
    [EnumMember(Value = "withdrawn")]
    Withdrawn,
    [EnumMember(Value = "draft")]
    Draft,
    [EnumMember(Value = "triage")]
    Triage,
}
