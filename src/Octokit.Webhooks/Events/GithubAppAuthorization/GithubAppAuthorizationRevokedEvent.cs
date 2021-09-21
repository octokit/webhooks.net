namespace Octokit.Webhooks.Events.GithubAppAuthorization
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(GithubAppAuthorizationActionValue.Revoked)]
    public sealed record GithubAppAuthorizationRevokedEvent : GithubAppAuthorizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => GithubAppAuthorizationAction.Revoked;
    }
}
