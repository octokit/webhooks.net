namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum TeamParentPrivacy
{
    [EnumMember(Value = "Open")]
    Open,
    [EnumMember(Value = "Closed")]
    Closed,
    [EnumMember(Value = "Secret")]
    Secret,
}
