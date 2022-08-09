namespace Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
public sealed record ChangesNote
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
