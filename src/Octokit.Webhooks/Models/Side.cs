namespace Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Side
    {
        [EnumMember(Value = "LEFT")]
        Left,
        [EnumMember(Value = "RIGHT")]
        Right,
    }
}
