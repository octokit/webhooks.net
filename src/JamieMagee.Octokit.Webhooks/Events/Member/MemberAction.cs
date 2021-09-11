namespace JamieMagee.Octokit.Webhooks.Events.Member
{
    public sealed class MemberAction : WebhookEventAction
    {
        public static readonly MemberAction Added = new(MemberActionValue.Added);

        public static readonly MemberAction Edited = new(MemberActionValue.Edited);

        public static readonly MemberAction Removed = new(MemberActionValue.Removed);

        private MemberAction(string value)
            : base(value)
        {
        }
    }
}
