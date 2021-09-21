namespace Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum InstallationTargetType
    {
        [EnumMember(Value = "User")]
        User,
        [EnumMember(Value = "Organization")]
        Organization,
    }
}
