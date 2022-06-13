namespace Octokit.Webhooks.Events.GithubAppAuthorization;

using JetBrains.Annotations;

[PublicAPI]
public sealed record GithubAppAuthorizationAction : WebhookEventAction
{
    public static readonly GithubAppAuthorizationAction Revoked = new(GithubAppAuthorizationActionValue.Revoked);

    private GithubAppAuthorizationAction(string value)
        : base(value)
    {
    }
}
