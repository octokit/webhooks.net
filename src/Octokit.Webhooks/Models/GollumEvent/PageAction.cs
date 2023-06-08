namespace Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
public enum PageAction
{
    [EnumMember(Value = "created")]
    Created,
    [EnumMember(Value = "edited")]
    Edited,
}
