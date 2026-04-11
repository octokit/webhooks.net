namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
