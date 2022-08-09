namespace Octokit.Webhooks.Models.IssuesEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
