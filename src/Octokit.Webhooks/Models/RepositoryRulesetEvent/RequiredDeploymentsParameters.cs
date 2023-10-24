namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record RequiredDeploymentsParameters
{
    [JsonPropertyName("required_deployment_environments ")]
    public IReadOnlyCollection<string>? RequiredDeploymentEnvironments { get; init; }
}
