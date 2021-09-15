namespace JamieMagee.Octokit.Webhooks.Events.DiscussionComment
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DiscussionCommentAction : WebhookEventAction
    {
        public static readonly DiscussionCommentAction Created = new(DiscussionCommentActionValue.Created);

        public static readonly DiscussionCommentAction Deleted = new(DiscussionCommentActionValue.Deleted);

        public static readonly DiscussionCommentAction Edited = new(DiscussionCommentActionValue.Edited);

        private DiscussionCommentAction(string value)
            : base(value)
        {
        }
    }
}
