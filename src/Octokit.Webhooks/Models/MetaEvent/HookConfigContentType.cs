namespace Octokit.Webhooks.Models.MetaEvent;

[PublicAPI]
public enum HookConfigContentType
{
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "form")]
    Form,
}
