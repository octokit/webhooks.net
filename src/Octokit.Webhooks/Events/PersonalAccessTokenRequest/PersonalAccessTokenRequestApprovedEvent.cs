namespace Octokit.Webhooks.Events.PersonalAccessTokenRequest;

[PublicAPI]
[WebhookActionType(PersonalAccessTokenRequestActionValue.Approved)]
public sealed record PersonalAccessTokenRequestApprovedEvent : PersonalAccessTokenRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PersonalAccessTokenRequestAction.Approved;
}
