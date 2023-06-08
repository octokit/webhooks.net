namespace Octokit.Webhooks.Models;

[PublicAPI]
public enum TeamPrivacy
{
    [EnumMember(Value = "Open")]
    Open,
    [EnumMember(Value = "Closed")]
    Closed,
    [EnumMember(Value = "Secret")]
    Secret,
}
