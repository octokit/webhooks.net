namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesEnforcementLevel
{
    [JsonPropertyName("from")]
    public EnforcementLevel? From { get; init; }
}
