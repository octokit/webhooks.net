namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesPrivacy
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
