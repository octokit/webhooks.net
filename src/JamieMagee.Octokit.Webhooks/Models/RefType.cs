namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum RefType
    {
        [EnumMember(Value = "tag")]
        Tag,
        [EnumMember(Value = "branch")]
        Branch,
    }
}
