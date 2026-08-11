namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public enum FieldType
{
    [EnumMember(Value = "single_select")]
    SingleSelect,
    [EnumMember(Value = "date")]
    Date,
    [EnumMember(Value = "number")]
    Number,
    [EnumMember(Value = "text")]
    Text,
    [EnumMember(Value = "iteration")]
    Iteration,
    [EnumMember(Value = "assignees")]
    Assignees,
    [EnumMember(Value = "reviewers")]
    Reviewers,
    [EnumMember(Value = "labels")]
    Labels,
}
