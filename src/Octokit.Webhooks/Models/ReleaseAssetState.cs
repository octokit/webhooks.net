namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ReleaseAssetState
{
    [EnumMember(Value = "uploaded")]
    Uploaded,
}