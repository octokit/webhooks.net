namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record ReferencedWorkflow
{
    [JsonPropertyName("path")]
    public string Path { get; init; } = null!;

    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
