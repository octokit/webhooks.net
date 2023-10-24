namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record WorkflowsParameters
{
    [JsonPropertyName("workflows")]
    public IReadOnlyCollection<Workflow>? Workflows { get; init; }
}
