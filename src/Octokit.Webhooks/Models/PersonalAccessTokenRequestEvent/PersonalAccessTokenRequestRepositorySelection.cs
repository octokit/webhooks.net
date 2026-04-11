namespace Octokit.Webhooks.Models.PersonalAccessTokenRequestEvent;

[PublicAPI]
public enum PersonalAccessTokenRequestRepositorySelection
{
    [EnumMember(Value = "none")]
    None,
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "subset")]
    Subset,
}
