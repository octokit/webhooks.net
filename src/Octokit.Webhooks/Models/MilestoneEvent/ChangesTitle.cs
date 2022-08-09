namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
