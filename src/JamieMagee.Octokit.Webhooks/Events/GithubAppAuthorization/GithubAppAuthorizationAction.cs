namespace JamieMagee.Octokit.Webhooks.Events.GithubAppAuthorization
{
    public sealed class GithubAppAuthorizationAction : WebhookEventAction
    {
        public static readonly GithubAppAuthorizationAction Revoked = new(GithubAppAuthorizationActionValue.Revoked);

        private GithubAppAuthorizationAction(string value)
            : base(value)
        {
        }
    }
}
