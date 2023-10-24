namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredDeployments
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("parameters")]
    public RequiredDeploymentsParameters? Parameters { get; init; }
}
