namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestEditedEventChanges
{
    [JsonPropertyName("body")]
    public PullRequestEditedEventChangesBody? Body { get; init; }

    [JsonPropertyName("title")]
    public PullRequestEditedEventChangesTitle? Title { get; init; }
}
