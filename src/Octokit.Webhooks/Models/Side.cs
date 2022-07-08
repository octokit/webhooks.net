namespace Octokit.Webhooks.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[JsonConverter(typeof(JsonStringEnumMemberConverterWithFallback))]
public enum Side
{
    [EnumMember(Value = "LEFT")]
    Left,
    [EnumMember(Value = "RIGHT")]
    Right,
}
