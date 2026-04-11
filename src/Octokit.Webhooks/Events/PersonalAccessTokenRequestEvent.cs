namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.PersonalAccessTokenRequest)]
[JsonConverter(typeof(WebhookConverter<PersonalAccessTokenRequestEvent>))]
public abstract record PersonalAccessTokenRequestEvent : WebhookEvent
{
    [JsonPropertyName("personal_access_token_request")]
    public required Models.PersonalAccessTokenRequestEvent.PersonalAccessTokenRequest PersonalAccessTokenRequest { get; init; }
}
