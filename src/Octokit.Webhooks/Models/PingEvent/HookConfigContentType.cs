namespace Octokit.Webhooks.Models.PingEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

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
