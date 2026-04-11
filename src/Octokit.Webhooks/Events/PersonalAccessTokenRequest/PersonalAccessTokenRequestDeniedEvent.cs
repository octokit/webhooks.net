namespace Octokit.Webhooks.Events.PersonalAccessTokenRequest;

[PublicAPI]
[WebhookActionType(PersonalAccessTokenRequestActionValue.Denied)]
public sealed record PersonalAccessTokenRequestDeniedEvent : PersonalAccessTokenRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PersonalAccessTokenRequestAction.Denied;
}
