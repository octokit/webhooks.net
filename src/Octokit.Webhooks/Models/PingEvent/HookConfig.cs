namespace Octokit.Webhooks.Models.PingEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record HookConfig
{
    [JsonPropertyName("content_type")]
    public HookConfigContentType ContentType { get; init; }

    [JsonPropertyName("secret")]
    public string? Secret { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("insecure_ssl")]
    public string InsecureSsl { get; init; } = null!;
}