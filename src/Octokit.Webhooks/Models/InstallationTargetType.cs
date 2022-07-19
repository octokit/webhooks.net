namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum InstallationTargetType
{
    Unknown = -1,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Organization")]
    Organization,
}
