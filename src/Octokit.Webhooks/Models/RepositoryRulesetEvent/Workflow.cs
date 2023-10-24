namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Workflow
{
    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    [JsonPropertyName("repository_id ")]
    public int? RepositoryId { get; init; }

    [JsonPropertyName("sha")]
    public string? Sha { get; init; }
}
