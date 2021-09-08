namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        [EnumMember(Value = "Bot")] Bot,
        [EnumMember(Value = "User")] User,
        [EnumMember(Value = "Organization")] Organization
    }
}
