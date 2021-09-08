namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum AppPermissionsLevel
    {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write
    }
}
