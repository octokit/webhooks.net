namespace JamieMagee.Octokit.Webhooks.Events.TeamAdd
{
    public sealed class TeamAddAction : WebhookEventAction
    {
        public static readonly TeamAddAction Event = new(TeamAddActionValue.Event);

        private TeamAddAction(string value)
            : base(value)
        {
        }
    }
}
