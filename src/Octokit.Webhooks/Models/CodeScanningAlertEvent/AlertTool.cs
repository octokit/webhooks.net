namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
public sealed record AlertTool
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }

    [JsonPropertyName("guid")]
    public string? Guid { get; init; }
}
