namespace Octokit.Webhooks.Models.IssueCommentEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public ChangesBody? Body { get; init; }
}
