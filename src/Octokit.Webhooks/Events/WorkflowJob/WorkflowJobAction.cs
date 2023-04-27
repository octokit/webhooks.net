namespace Octokit.Webhooks.Events.WorkflowJob;

[PublicAPI]
public sealed record WorkflowJobAction : WebhookEventAction
{
    public static readonly WorkflowJobAction Queued = new(WorkflowJobActionValue.Queued);

    public static readonly WorkflowJobAction InProgress = new(WorkflowJobActionValue.InProgress);

    public static readonly WorkflowJobAction Completed = new(WorkflowJobActionValue.Completed);

    public static readonly WorkflowJobAction Waiting = new(WorkflowJobActionValue.Waiting);

    private WorkflowJobAction(string value)
        : base(value)
    {
    }
}
