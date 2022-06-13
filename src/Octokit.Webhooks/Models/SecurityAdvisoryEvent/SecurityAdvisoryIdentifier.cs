namespace Octokit.Webhooks.Models.SecurityAdvisoryEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record SecurityAdvisoryIdentifier
{
    [JsonPropertyName("value")]
    public string Value { get; init; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;
}