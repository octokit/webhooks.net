namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesArray
{
    [JsonPropertyName("from")]
    public IEnumerable<string>? From { get; init; }
}
