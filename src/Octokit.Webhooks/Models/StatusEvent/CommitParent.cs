namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitParent
{
    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = null!;
}
