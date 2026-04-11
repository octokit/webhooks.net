namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryAdvisory)]
[JsonConverter(typeof(WebhookConverter<RepositoryAdvisoryEvent>))]
public abstract record RepositoryAdvisoryEvent : WebhookEvent
{
    [JsonPropertyName("repository_advisory")]
    public required Models.RepositoryAdvisoryEvent.RepositoryAdvisory RepositoryAdvisory { get; init; }
}
