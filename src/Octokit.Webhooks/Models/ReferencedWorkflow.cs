namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ReferencedWorkflow
{
    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }
}
