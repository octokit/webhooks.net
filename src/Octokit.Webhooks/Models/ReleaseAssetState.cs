namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum ReleaseAssetState
{
    Unknown = -1,
    [EnumMember(Value = "uploaded")]
    Uploaded,
}
