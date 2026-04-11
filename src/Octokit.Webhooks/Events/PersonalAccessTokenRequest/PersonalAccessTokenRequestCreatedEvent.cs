namespace Octokit.Webhooks.Events.PersonalAccessTokenRequest;

[PublicAPI]
[WebhookActionType(PersonalAccessTokenRequestActionValue.Created)]
public sealed record PersonalAccessTokenRequestCreatedEvent : PersonalAccessTokenRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PersonalAccessTokenRequestAction.Created;
}
