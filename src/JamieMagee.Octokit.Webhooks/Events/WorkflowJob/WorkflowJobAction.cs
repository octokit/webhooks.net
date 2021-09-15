namespace JamieMagee.Octokit.Webhooks.Events.WorkflowJob
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record WorkflowJobAction : WebhookEventAction
    {
        public static readonly WorkflowJobAction Completed = new(WorkflowJobActionValue.Completed);

        public static readonly WorkflowJobAction Started = new(WorkflowJobActionValue.Started);

        private WorkflowJobAction(string value)
            : base(value)
        {
        }
    }
}
