namespace JamieMagee.Octokit.Webhooks.Events.Star
{
    public sealed class StarAction : WebhookEventAction
    {
        public static readonly StarAction Created = new(StarActionValue.Created);

        public static readonly StarAction Deleted = new(StarActionValue.Deleted);

        private StarAction(string value)
            : base(value)
        {
        }
    }
}
