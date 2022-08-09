namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum FieldType
{
    Unknown = -1,
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
}
