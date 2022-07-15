namespace Octokit.Webhooks.Models.BranchProtectionRuleEvent;

[PublicAPI]
public sealed record ChangesEnforcementLevel
{
    [JsonPropertyName("from")]
    [JsonConverter(typeof(StringEnumConverter<EnforcementLevel>))]
    public StringEnum<EnforcementLevel>? From { get; init; }
}
