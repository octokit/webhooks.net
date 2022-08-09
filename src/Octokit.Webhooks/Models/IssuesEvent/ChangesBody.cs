namespace Octokit.Webhooks.Models.IssuesEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
