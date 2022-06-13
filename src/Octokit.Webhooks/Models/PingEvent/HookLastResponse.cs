namespace Octokit.Webhooks.Models.PingEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record HookLastResponse
{
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; } = null!;

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}