namespace Octokit.Webhooks.Models.MemberEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ChangesPermission
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}