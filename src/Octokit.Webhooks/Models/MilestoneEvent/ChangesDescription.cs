namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesDescription
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
