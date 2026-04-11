namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestLinks
{
    [JsonPropertyName("self")]
    public required Link Self { get; init; }

    [JsonPropertyName("html")]
    public required Link Html { get; init; }

    [JsonPropertyName("issue")]
    public required Link Issue { get; init; }

    [JsonPropertyName("comments")]
    public required Link Comments { get; init; }

    [JsonPropertyName("review_comments")]
    public required Link ReviewComments { get; init; }

    [JsonPropertyName("review_comment")]
    public required Link ReviewComment { get; init; }

    [JsonPropertyName("commits")]
    public required Link Commits { get; init; }

    [JsonPropertyName("statuses")]
    public required Link Statuses { get; init; }
}
