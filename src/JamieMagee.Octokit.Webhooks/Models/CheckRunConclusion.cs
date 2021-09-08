namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CheckRunConclusion
    {
         [EnumMember(Value = "actionRequired")]
         ActionRequired,
         [EnumMember(Value = "cancelled")]
         Cancelled,
         [EnumMember(Value = "failure")]
         Failure,
         [EnumMember(Value = "neutral")]
         Neutral,
         [EnumMember(Value = "skipped")]
         Skipped,
         [EnumMember(Value = "stale")]
         Stale,
         [EnumMember(Value = "success")]
         Success,
         [EnumMember(Value = "timed_out")]
         TimedOut
    }
}
