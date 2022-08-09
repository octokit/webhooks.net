namespace Octokit.Webhooks.Models.GollumEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum PageAction
{
    Unknown = -1,
    [EnumMember(Value = "created")]
    Created,
    [EnumMember(Value = "edited")]
    Edited,
}
