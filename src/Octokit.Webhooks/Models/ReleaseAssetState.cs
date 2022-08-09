namespace Octokit.Webhooks.Models;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ReleaseAssetState
{
    Unknown = -1,
    [EnumMember(Value = "uploaded")]
    Uploaded,
}
