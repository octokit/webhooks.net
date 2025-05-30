namespace Octokit.Webhooks.Events.RepositoryAdvisory;

[PublicAPI]
[WebhookActionType(RepositoryAdvisoryActionValue.Reported)]
public sealed record RepositoryAdvisoryReportedEvent : RepositoryAdvisoryEvent
{
    [JsonPropertyName("action")]
    public override string Action => RepositoryAdvisoryAction.Reported;
}
