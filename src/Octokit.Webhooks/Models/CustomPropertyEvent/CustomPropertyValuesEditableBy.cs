namespace Octokit.Webhooks.Models.CustomPropertyEvent;

[PublicAPI]
public enum CustomPropertyValuesEditableBy
{
    [EnumMember(Value = "org_actors")]
    OrgActors,

    [EnumMember(Value = "org_and_repo_actors")]
    OrgAndRepoActors,
}
