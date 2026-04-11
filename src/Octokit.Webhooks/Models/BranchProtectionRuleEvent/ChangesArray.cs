namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesArray
{
    [JsonPropertyName("from")]
    public IReadOnlyList<string>? From { get; init; }
}
