namespace Octokit.Webhooks.Models.MembershipAddedEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Scope
{
    [EnumMember(Value = "team")]
    Team,
}
