namespace Octokit.Webhooks.Models.RepositoryImportEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum Status
{
    Unknown = -1,
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "failure")]
    Failure,
}
