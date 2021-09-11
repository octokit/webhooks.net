namespace JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch
{
    public sealed class RepositoryDispatchAction : WebhookEventAction
    {
        public static readonly RepositoryDispatchAction OnDemandTest = new(RepositoryDispatchActionValue.OnDemandTest);

        private RepositoryDispatchAction(string value)
            : base(value)
        {
        }
    }
}
