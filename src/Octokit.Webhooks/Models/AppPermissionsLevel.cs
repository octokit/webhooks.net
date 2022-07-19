namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum AppPermissionsLevel
{
    Unknown = -1,
    [EnumMember(Value = "read")]
    Read,
    [EnumMember(Value = "write")]
    Write,
}
