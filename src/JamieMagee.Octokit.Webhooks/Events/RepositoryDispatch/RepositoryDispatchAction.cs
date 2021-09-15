namespace JamieMagee.Octokit.Webhooks.Events.RepositoryDispatch
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record RepositoryDispatchAction : WebhookEventAction
    {
        public static readonly RepositoryDispatchAction OnDemandTest = new(RepositoryDispatchActionValue.OnDemandTest);

        private RepositoryDispatchAction(string value)
            : base(value)
        {
        }
    }
}
