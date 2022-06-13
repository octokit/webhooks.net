namespace Octokit.Webhooks.Models.CodeScanningAlertEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record AlertInstanceLocation
{
    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("start_line")]
    public int? StartLine { get; init; }

    [JsonPropertyName("end_line")]
    public int? EndLine { get; init; }

    [JsonPropertyName("start_column")]
    public int? StartColumn { get; init; }

    [JsonPropertyName("end_column")]
    public int? EndColumn { get; init; }
}
