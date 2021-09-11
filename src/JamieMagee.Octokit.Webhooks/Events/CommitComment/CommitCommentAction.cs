namespace JamieMagee.Octokit.Webhooks.Events.CommitComment
{
    public sealed class CommitCommentAction : WebhookEventAction
    {
        public static readonly CommitCommentAction Created = new(CommitCommentActionValue.Created);

        private CommitCommentAction(string value)
            : base(value)
        {
        }
    }
}
