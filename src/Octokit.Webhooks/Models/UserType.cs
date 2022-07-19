namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum UserType
{
    Unknown = -1,
    [EnumMember(Value = "Bot")]
    Bot,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
