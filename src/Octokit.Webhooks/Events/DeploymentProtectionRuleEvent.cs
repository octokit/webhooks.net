namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentProtectionRule)]
[JsonConverter(typeof(WebhookConverter<DeploymentProtectionRuleEvent>))]
public abstract record DeploymentProtectionRuleEvent : WebhookEvent
{
    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

    [JsonPropertyName("event")]
    public required string Event { get; init; }

    [JsonPropertyName("deployment_callback_url")]
    public required string DeploymentCallbackUrl { get; init; }

    [JsonPropertyName("deployment")]
    public required Models.DeploymentEvent.Deployment Deployment { get; init; }

    [JsonPropertyName("pull_requests")]
    public required IReadOnlyList<Models.PullRequestEvent.PullRequest> PullRequests { get; init; }
}
