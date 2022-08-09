namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
