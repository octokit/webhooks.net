namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PullRequestState
    {
        [EnumMember(Value = "open")] Open,
        [EnumMember(Value = "closed")] Closed
    }
}
