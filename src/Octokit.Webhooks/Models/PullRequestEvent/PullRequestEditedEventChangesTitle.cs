namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestEditedEventChangesTitle
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
