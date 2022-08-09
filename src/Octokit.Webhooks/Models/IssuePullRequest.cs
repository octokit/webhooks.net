namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record IssuePullRequest
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; init; }

    [JsonPropertyName("diff_url")]
    public string? DiffUrl { get; init; }

    [JsonPropertyName("patch_url")]
    public string? PatchUrl { get; init; }
}
