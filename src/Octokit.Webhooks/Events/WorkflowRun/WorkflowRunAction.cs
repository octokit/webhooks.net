namespace Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
public sealed record WorkflowRunAction : WebhookEventAction
{
    public static readonly WorkflowRunAction Completed = new(WorkflowRunActionValue.Completed);

    public static readonly WorkflowRunAction Requested = new(WorkflowRunActionValue.Requested);

    private WorkflowRunAction(string value)
        : base(value)
    {
    }
}
