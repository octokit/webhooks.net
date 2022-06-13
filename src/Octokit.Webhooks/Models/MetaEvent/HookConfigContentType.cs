namespace Octokit.Webhooks.Models.MetaEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum HookConfigContentType
{
    [EnumMember(Value = "json")]
    Json,
    [EnumMember(Value = "form")]
    Form,
}
