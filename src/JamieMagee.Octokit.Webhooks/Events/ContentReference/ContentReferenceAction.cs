namespace JamieMagee.Octokit.Webhooks.Events.ContentReference
{
    public sealed class ContentReferenceAction : WebhookEventAction
    {
        public static readonly ContentReferenceAction Created = new(ContentReferenceActionValue.Created);

        private ContentReferenceAction(string value)
            : base(value)
        {
        }
    }
}
