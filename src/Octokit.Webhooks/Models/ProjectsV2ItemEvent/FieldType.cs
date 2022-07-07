namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
}
