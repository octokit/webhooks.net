namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestEditedEventChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
