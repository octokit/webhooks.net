namespace Octokit.Webhooks.Events.GithubAppAuthorization;

[PublicAPI]
[WebhookActionType(GithubAppAuthorizationActionValue.Revoked)]
public sealed record GithubAppAuthorizationRevokedEvent : GithubAppAuthorizationEvent
{
    [JsonPropertyName("action")]
    public override string Action => GithubAppAuthorizationAction.Revoked;
}
