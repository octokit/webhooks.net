namespace Octokit.Webhooks.Models.MembershipAddedEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Scope
{
    [EnumMember(Value = "team")]
    Team,
}
