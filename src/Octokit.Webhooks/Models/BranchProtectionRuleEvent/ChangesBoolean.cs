namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesBoolean
{
    [JsonPropertyName("from")]
    public bool? From { get; init; }
}
