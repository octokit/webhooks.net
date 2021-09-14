namespace JamieMagee.Octokit.Webhooks.Models.GollumEvent
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum PageAction
    {
        [EnumMember(Value = "created")]
        Created,
        [EnumMember(Value = "edited")]
        Edited,
    }
}
