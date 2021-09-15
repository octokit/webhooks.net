namespace JamieMagee.Octokit.Webhooks.Events.Delete
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DeleteAction : WebhookEventAction
    {
        public static readonly DeleteAction Event = new(DeleteActionValue.Event);

        private DeleteAction(string value)
            : base(value)
        {
        }
    }
}
