namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
