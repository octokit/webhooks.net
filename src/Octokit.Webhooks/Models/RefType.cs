namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum RefType
{
    Unknown = -1,
    [EnumMember(Value = "tag")]
    Tag,
    [EnumMember(Value = "branch")]
    Branch,
}
