namespace Octokit.Webhooks.Models.IssueCommentEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
