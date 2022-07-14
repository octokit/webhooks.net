namespace Octokit.Webhooks.Models.MembershipAddedEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum Scope
{
    Unknown = -1,
    [EnumMember(Value = "team")]
    Team,
}
