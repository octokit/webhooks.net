namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public enum HookType
{
    [EnumMember(Value = "Repository")]
    Repository,
    [EnumMember(Value = "Organization")]
    Organization,
    [EnumMember(Value = "App")]
    App,
}
