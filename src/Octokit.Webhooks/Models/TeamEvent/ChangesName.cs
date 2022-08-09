namespace Octokit.Webhooks.Models.TeamEvent;

[PublicAPI]
public sealed record ChangesName
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
