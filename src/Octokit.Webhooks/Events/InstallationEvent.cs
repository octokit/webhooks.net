namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Installation)]
[JsonConverter(typeof(WebhookConverter<InstallationEvent>))]
public abstract record InstallationEvent : WebhookEvent
{
    [JsonPropertyName("installation")]
    public new Models.Installation Installation { get; init; } = null!;

    [JsonPropertyName("repositories")]
    public IEnumerable<Models.InstallationEvent.Repository> Repositories { get; init; } = null!;

    [JsonPropertyName("requester")]
    public User? Requester { get; init; }
}
