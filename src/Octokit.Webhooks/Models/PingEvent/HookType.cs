namespace Octokit.Webhooks.Models.PingEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum HookType
{
    [EnumMember(Value = "Repository")]
    Repository,
    [EnumMember(Value = "Organization")]
    Organization,
    [EnumMember(Value = "App")]
    App,
}
