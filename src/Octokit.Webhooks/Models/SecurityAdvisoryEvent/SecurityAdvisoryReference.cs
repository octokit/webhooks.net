namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record SecurityAdvisoryReference
{
    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;
}