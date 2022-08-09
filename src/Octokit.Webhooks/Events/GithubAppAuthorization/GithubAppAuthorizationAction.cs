namespace Octokit.Webhooks.Events.GithubAppAuthorization;

[PublicAPI]
public sealed record GithubAppAuthorizationAction : WebhookEventAction
{
    public static readonly GithubAppAuthorizationAction Revoked = new(GithubAppAuthorizationActionValue.Revoked);

    private GithubAppAuthorizationAction(string value)
        : base(value)
    {
    }
}
