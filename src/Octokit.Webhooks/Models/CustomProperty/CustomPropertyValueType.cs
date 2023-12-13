namespace Octokit.Webhooks.Models.CustomProperty;

[PublicAPI]
public enum CustomPropertyValueType
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "single_select")]
    SingleSelect,
}
