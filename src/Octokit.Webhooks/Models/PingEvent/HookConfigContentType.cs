namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
public enum HookConfigContentType
{
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "form")]
    Form,
}
