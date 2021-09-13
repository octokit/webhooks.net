namespace JamieMagee.Octokit.Webhooks.Events.GithubAppAuthorization
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(GithubAppAuthorizationActionValue.Revoked)]
    public sealed record GithubAppAuthorizationRevokedEvent : GithubAppAuthorizationEvent
    {
        [JsonPropertyName("action")]
        public override string Action => GithubAppAuthorizationAction.Revoked;
    }
}
