namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
