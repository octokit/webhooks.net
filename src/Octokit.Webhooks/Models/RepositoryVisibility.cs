namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum RepositoryVisibility
{
    [EnumMember(Value = "public")]
    Public,
    [EnumMember(Value = "private")]
    Private,
    [EnumMember(Value = "internal")]
    Internal,
}
