namespace Octokit.Webhooks.Models.CustomPropertyEvent;

[PublicAPI]
public enum CustomPropertyValueType
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "single_select")]
    SingleSelect,

    [EnumMember(Value = "multi_select")]
    MultiSelect,

    [EnumMember(Value = "true_false")]
    TrueFalse,
}
