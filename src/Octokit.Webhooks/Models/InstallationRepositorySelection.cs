namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum InstallationRepositorySelection
{
    Unknown = -1,
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "selected")]
    Selected,
}
