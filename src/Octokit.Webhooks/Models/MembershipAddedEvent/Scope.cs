namespace Octokit.Webhooks.Models.MembershipAddedEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum Scope
{
    Unknown = -1,
    [EnumMember(Value = "team")]
    Team,
}
