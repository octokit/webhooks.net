namespace Octokit.Webhooks.Models.RepositoryImportEvent;

[PublicAPI]
public enum Status
{
    [EnumMember(Value = "success")]
    Success,
    [EnumMember(Value = "cancelled")]
    Cancelled,
    [EnumMember(Value = "failure")]
    Failure,
}
