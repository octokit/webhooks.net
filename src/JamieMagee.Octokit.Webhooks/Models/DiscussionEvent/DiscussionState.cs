namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DiscussionState
    {
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value = "locked")]
        Locked,
        [EnumMember(Value = "converting")]
        Converting,
    }
}
