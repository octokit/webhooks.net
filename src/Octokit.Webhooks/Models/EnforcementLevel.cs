namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum EnforcementLevel
{
    [EnumMember(Value = "off")]
    Off,
    [EnumMember(Value = "non_admins")]
    NonAdmins,
    [EnumMember(Value = "everyone")]
    Everyone,
}
