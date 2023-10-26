namespace Octokit.Webhooks.Models.RepositoryRulesetEvent;

[PublicAPI]
public sealed record Workflows
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("parameters")]
    public WorkflowsParameters? Parameters { get; init; }
}
