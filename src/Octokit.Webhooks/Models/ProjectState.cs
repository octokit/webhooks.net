namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum ProjectState
{
    [EnumMember(Value = "open")]
    Open,
    [EnumMember(Value = "closed")]
    Closed,
}
