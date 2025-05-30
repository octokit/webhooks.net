namespace Octokit.Webhooks.Events.RepositoryAdvisory;

[PublicAPI]
[WebhookActionType(RepositoryAdvisoryActionValue.Published)]
public sealed record RepositoryAdvisoryPublishedEvent : RepositoryAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAdvisoryAction.Published;
}
