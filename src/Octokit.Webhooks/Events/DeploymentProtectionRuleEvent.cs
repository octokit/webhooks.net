namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentProtectionRule)]
[JsonConverter(typeof(WebhookConverter<DeploymentProtectionRuleEvent>))]
public abstract record DeploymentProtectionRuleEvent : WebhookEvent
{
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
