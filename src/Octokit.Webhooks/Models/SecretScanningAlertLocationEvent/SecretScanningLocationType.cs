namespace Octokit.Webhooks.Models.SecretScanningAlertLocationEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum SecretScanningLocationType
{
    Unknown = -1,
    [EnumMember(Value = "commit")]
    Commit,
    [EnumMember(Value = "issue_title")]
    IssueTitle,
    [EnumMember(Value = "issue_body")]
    IssueBody,
    [EnumMember(Value = "issue_comment")]
    IssueComment,
}
