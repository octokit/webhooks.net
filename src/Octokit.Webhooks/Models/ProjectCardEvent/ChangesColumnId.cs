namespace Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
public sealed record ChangesColumnId
{
    [JsonPropertyName("from")]
    public long From { get; init; }
}
