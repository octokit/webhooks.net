namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesInteger
{
    [JsonPropertyName("from")]
    public long? From { get; init; }
}
