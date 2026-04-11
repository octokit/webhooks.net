namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitParent
{
    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }
}
