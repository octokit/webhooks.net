namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredStatusChecksParameters
{
    [JsonPropertyName("required_status_checks ")]
    public IReadOnlyCollection<RequiredStatusChecks>? RequiredStatusChecks { get; init; }

    [JsonPropertyName("strict_required_status_checks_policy")]
    public bool StrictRequiredStatusChecksPolicy { get; init; }
}
