namespace Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
public sealed record ChangesNote
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
