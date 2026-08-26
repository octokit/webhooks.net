namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestStackBase
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }
}
