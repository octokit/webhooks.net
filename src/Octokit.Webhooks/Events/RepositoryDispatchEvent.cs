namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryDispatch)]
[JsonConverter(typeof(WebhookConverter<RepositoryDispatchEvent>))]
public abstract record RepositoryDispatchEvent : WebhookEvent
{
    [JsonPropertyName("branch")]
    public string Branch { get; init; } = null!;

    [JsonPropertyName("client_payload")]
    public dynamic ClientPayload { get; init; } = null!;
}
