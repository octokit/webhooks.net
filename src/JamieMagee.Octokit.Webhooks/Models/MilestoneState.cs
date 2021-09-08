namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MilestoneState
    {
        [EnumMember(Value = "open")] Open,
        [EnumMember(Value = "closed")] Closed
    }
}
