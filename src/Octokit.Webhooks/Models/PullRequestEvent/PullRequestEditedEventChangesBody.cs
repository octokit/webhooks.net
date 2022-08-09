namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestEditedEventChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
