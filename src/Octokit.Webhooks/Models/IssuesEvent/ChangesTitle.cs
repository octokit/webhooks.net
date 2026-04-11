namespace Octokit.Webhooks.Models.IssuesEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
