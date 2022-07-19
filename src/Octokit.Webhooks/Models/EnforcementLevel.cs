namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum EnforcementLevel
{
    Unknown = -1,
    [EnumMember(Value = "off")]
    Off,
    [EnumMember(Value = "non_admins")]
    NonAdmins,
    [EnumMember(Value = "everyone")]
    Everyone,
}
