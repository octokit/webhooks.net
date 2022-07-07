namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum InstallationRepositorySelection
{
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "selected")]
    Selected,
}
