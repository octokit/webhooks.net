namespace Octokit.Webhooks.Models.IssueCommentEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
