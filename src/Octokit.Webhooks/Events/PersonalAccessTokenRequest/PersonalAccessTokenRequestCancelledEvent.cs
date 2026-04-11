namespace Octokit.Webhooks.Events.PersonalAccessTokenRequest;

[PublicAPI]
[WebhookActionType(PersonalAccessTokenRequestActionValue.Cancelled)]
public sealed record PersonalAccessTokenRequestCancelledEvent : PersonalAccessTokenRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PersonalAccessTokenRequestAction.Cancelled;
}
