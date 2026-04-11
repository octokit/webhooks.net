namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesPrivacy
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
