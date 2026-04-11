namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
