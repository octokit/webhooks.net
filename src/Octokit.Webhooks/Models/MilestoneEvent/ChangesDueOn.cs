namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesDueOn
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
