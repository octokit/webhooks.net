namespace Octokit.Webhooks.Models.MetaEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum HookConfigContentType
{
    Unknown = -1,
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "form")]
    Form,
}
