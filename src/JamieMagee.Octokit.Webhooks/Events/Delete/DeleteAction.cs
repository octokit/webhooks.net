namespace JamieMagee.Octokit.Webhooks.Events.Delete
{
    public sealed class DeleteAction : WebhookEventAction
    {
        public static readonly DeleteAction Event = new(DeleteActionValue.Event);

        private DeleteAction(string value)
            : base(value)
        {
        }
    }
}
