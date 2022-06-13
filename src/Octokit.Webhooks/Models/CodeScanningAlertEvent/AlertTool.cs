namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record AlertTool
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("version")]
    public string? Version { get; init; }

    [JsonPropertyName("guid")]
    public string? Guid { get; init; }
}
