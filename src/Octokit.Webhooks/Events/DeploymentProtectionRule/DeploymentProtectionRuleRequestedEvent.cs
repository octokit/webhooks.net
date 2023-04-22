namespace Octokit.Webhooks.Events.DeploymentProtectionRule;

[PublicAPI]
[WebhookActionType(DeploymentProtectionRuleActionValue.Requested)]
public sealed record DeploymentProtectionRuleRequestedEvent : DeploymentProtectionRuleEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentProtectionRuleAction.Requested;

    [JsonPropertyName("environment")]
    public string Environment { get; init; } = null!;

    [JsonPropertyName("event")]
    public string Event { get; init; } = null!;

    [JsonPropertyName("deployment_callback_url")]
    public string DeploymentCallbackUrl { get; init; } = null!;

    [JsonPropertyName("deployment")]
    public Models.DeploymentEvent.Deployment Deployment { get; init; } = null!;

    [JsonPropertyName("pull_requests")]
    public IEnumerable<Models.PullRequestEvent.PullRequest> PullRequests { get; init; } = null!;
}
