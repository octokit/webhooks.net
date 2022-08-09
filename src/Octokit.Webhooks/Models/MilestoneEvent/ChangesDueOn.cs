namespace Octokit.Webhooks.Models.MilestoneEvent;

[PublicAPI]
public sealed record ChangesDueOn
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
