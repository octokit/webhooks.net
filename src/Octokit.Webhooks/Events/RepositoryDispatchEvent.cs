namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryDispatch)]
[JsonConverter(typeof(WebhookConverter<RepositoryDispatchEvent>))]
public abstract record RepositoryDispatchEvent : WebhookEvent
{
    [JsonPropertyName("branch")]
    public required string Branch { get; init; }

    [JsonPropertyName("client_payload")]
    public required dynamic ClientPayload { get; init; }
}
