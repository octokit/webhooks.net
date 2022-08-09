namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestEditedEventChangesTitle
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
