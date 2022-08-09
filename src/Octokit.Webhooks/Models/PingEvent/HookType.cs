namespace Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum HookType
{
    Unknown = -1,
    [EnumMember(Value = "Repository")]
    Repository,
    [EnumMember(Value = "Organization")]
    Organization,
    [EnumMember(Value = "App")]
    App,
}
